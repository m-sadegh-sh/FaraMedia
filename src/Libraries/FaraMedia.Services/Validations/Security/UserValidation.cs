namespace FaraMedia.Services.Validations.Security {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Extensions.Security;
    using FaraMedia.Services.Querying.Security;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class UserValidation : EntityValidationBase<User> {
        public UserValidation() {
            Define(u => u.SystemName)
                .MaxLength(UserConstants.Fields.SystemName.Length)
                .WithInvalidLength(UserConstants.Fields.SystemName.Label,
                                   UserConstants.Fields.SystemName.Length);

            Define(u => u.UserName)
                .MaxLength(UserConstants.Fields.UserName.Length)
                .WithInvalidLength(UserConstants.Fields.UserName.Label,
                                   UserConstants.Fields.UserName.Length);

            Define(u => u.Email)
                .NotNullableAndNotEmpty()
                .WithRequired(UserConstants.Fields.Email.Label)
                .And
                .MaxLength(UserConstants.Fields.Email.Length)
                .WithInvalidLength(UserConstants.Fields.Email.Label,
                                   UserConstants.Fields.Email.Length)
                .And
                .IsEmail()
                .WithInvalidFormat(UserConstants.Fields.Email.Label);

            Define(u => u.Password)
                .NotNullableAndNotEmpty()
                .WithRequired(UserConstants.Fields.Password.Label)
                .And
                .MaxLength(UserConstants.Fields.Password.Length)
                .WithInvalidLength(UserConstants.Fields.Password.Label,
                                   UserConstants.Fields.Password.Length);

            Define(u => u.PasswordSalt)
                .MaxLength(UserConstants.Fields.PasswordSalt.Length);

            Define(u => u.PasswordFormat);

            Define(u => u.LastLoginDateUtc);

            Define(u => u.LastActivityDateUtc);

            Define(u => u.LastIpAddress)
                .MaxLength(UserConstants.Fields.LastIpAddress.Length);

            Define(u => u.AdminComment)
                .MaxLength();

            Define(u => u.CurrentBlockType);

            Define(u => u.Roles);

            Define(u => u.Activities);

            Define(u => u.Logs);

            Define(u => u.ToDos);

            Define(u => u.Tickets);

            Define(u => u.Responses);

            Define(u => u.IncomingFriendRequests);

            Define(u => u.OutgoingFriendRequests);

            Define(u => u.Blogs);

            Define(u => u.Orders);

            Define(u => u.Likes);

            Define(u => u.Shares);

            Define(u => u.VotingRecords);

            ValidateInstance.SafeBy((user, context) => {
                                        var isValid = true;

                                        var settings = EngineContext.Current.Resolve<SecuritySettings>();

                                        if (settings.UserNamesEnabled) {
                                            Define(u => u.UserName)
                                                .NotNullableAndNotEmpty()
                                                .WithRequired(UserConstants.Fields.UserName.Label);
                                        }

                                        var service = EngineContext.Current.Resolve<IDbService<User, UserQuery>>();

                                        if (service.GetBySystemName(user.SystemName).IsDuplicate(user)) {
                                            context.AddDuplicate<User, string>(UserConstants.Fields.SystemName.Label,
                                                                               u => u.SystemName);

                                            isValid = false;
                                        }

                                        if (settings.UserNamesEnabled) {
                                            if (service.GetByUserName(user.UserName).IsDuplicate(user)) {
                                                context.AddDuplicate<User, string>(UserConstants.Fields.UserName.Label,
                                                                                   u => u.UserName);

                                                isValid = false;
                                            }
                                        } else
                                            user.UserName = user.Email;

                                        if (service.GetByEmail(user.Email).IsDuplicate(user)) {
                                            context.AddDuplicate<User, string>(UserConstants.Fields.Email.Label,
                                                                               u => u.Email);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}