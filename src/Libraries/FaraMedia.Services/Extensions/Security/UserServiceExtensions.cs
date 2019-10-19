namespace FaraMedia.Services.Extensions.Security {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Operators;
    using FaraMedia.Core.SafeCode;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Querying.Security;
    using FaraMedia.Services.Requests.Security;
    using FaraMedia.Services.Utilities;

    using NHibernate.Validator.Engine;

    public static class UserServiceExtensions {
        public static User GetBySystemName(this IDbService<User, UserQuery> service, string systemName) {
			if (Neutrals.Is(systemName))
                return null;

            var user = service.Get(uq => uq.WithSystemName(systemName));

            return user;
        }

        public static User GetByUserName(this IDbService<User, UserQuery> service, string userName) {
			if (Neutrals.Is(userName))
                return null;

            var user = service.Get(uq => uq.WithUserName(userName));

            return user;
        }

        public static User GetByEmail(this IDbService<User, UserQuery> service, string email) {
			if (Neutrals.Is(email))
                return null;

	        var user = service.Get(uq => uq.WithEmail(email));

            return user;
        }

        public static IList<User> GetOnlineUsers(this IDbService<User, UserQuery> service, DateTime lastActivityFromUtc, long[] roleIds) {
            var users = service.GetAll(uq => uq.WithLastActivityDateUtcBetween(lastActivityFromUtc).WithCurrentBlockReason(null,ArgumentEvaluationMode.Explicit).WithRoleIds(roleIds));

            return users;
        }

        public static ServiceOperationResultWithValue<bool> ValidateUser(this IDbService<User, UserQuery> service, string userNameOrEmail, string password) {
            var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<bool>>();

            var validatorEngine = EngineContext.Current.Resolve<ValidatorEngine>();

            var tempUser = new User {
                Password = password
            };

            var securitySettings = EngineContext.Current.Resolve<SecuritySettings>();

            if (securitySettings.UserNamesEnabled) {
                tempUser.UserName = userNameOrEmail;
                result.InjectInvalidValues(validatorEngine.ValidatePropertyValue(tempUser, u => u.UserName));
            } else {
                tempUser.Email = userNameOrEmail;
                result.InjectInvalidValues(validatorEngine.ValidatePropertyValue(tempUser, u => u.Email));
            }

            result.InjectInvalidValues(validatorEngine.ValidatePropertyValue(tempUser, u => u.Password));

            if (!result.Success)
                return result;

            User user;

            if (securitySettings.UserNamesEnabled)
                user = service.GetByUserName(userNameOrEmail);
            else
                user = service.GetByEmail(userNameOrEmail);

            if (user == null) {
                result.AddResourceError(UserConstants.Messages.InvalidUserNameOrEmail);
                return result.With(false);
            }

            if (user.CurrentBlockTypeId.HasValue) {
                result.AddResourceError(UserConstants.Messages.YourAccountIsNotActivatedYet, user.CurrentBlockType.Description);
                return result.With(false);
            }
            
            if (!user.IsRegistered()) {
                result.AddResourceError(UserConstants.Messages.YourAccountIsNotValid);
                return result.With(false);
            }

            string dbPassword;

            var encryptionService = EngineContext.Current.Resolve<IEncryptionService>();

            switch (user.PasswordFormat) {
                case PasswordStoringFormat.Encrypted:
                    dbPassword = encryptionService.EncryptText(password);
                    break;
                case PasswordStoringFormat.Hashed:
                    dbPassword = encryptionService.CreatePasswordHash(password, user.PasswordSalt, securitySettings.HashAlgorithm);
                    break;
                default:
                    dbPassword = password;
                    break;
            }

            var isValid = dbPassword == user.Password;

            if (isValid) {
                user.LastLoginDateUtc = DateTime.UtcNow;
                service.Save(user);
            }

            if (!isValid)
                result.AddResourceError(UserConstants.Messages.InvalidUserNameEmailOrPassword);

            return result.With(isValid);
        }

        public static ServiceOperationResult RegisterUser(this IDbService<User, UserQuery> service, UserRegistrationRequest userRegistrationRequest) {
            var result = EngineContext.Current.Resolve<ServiceOperationResult>();

            if (userRegistrationRequest == null || userRegistrationRequest.User == null) {
                result.AddResourceError(CommonConstants.Messages.NullEntity);
                return result;
            }

            if (service.GetById(userRegistrationRequest.User.Id) == null) {
                result.AddResourceError(CommonConstants.Messages.UnknownEntity);
                return result;
            }

            if (userRegistrationRequest.User.IsSearchEngineAccount()) {
                result.AddResourceError(UserConstants.Messages.SearchEngine);
                return result;
            }

            if (userRegistrationRequest.User.IsRegistered()) {
                result.AddResourceError(UserConstants.Messages.AlreadyRegistered);
                return result;
            }

            userRegistrationRequest.User.UserName = userRegistrationRequest.UserName;
            userRegistrationRequest.User.Email = userRegistrationRequest.Email;
            userRegistrationRequest.User.PasswordFormat = userRegistrationRequest.PasswordFormat;

            var encryptionService = EngineContext.Current.Resolve<IEncryptionService>();

            switch (userRegistrationRequest.PasswordFormat) {
                case PasswordStoringFormat.Clear:
                    userRegistrationRequest.User.Password = userRegistrationRequest.Password;

                    break;
                case PasswordStoringFormat.Encrypted:
                    userRegistrationRequest.User.Password = encryptionService.EncryptText(userRegistrationRequest.Password);

                    break;
                case PasswordStoringFormat.Hashed:
                    var saltKey = encryptionService.CreateSaltKey(UserConstants.Fields.PasswordSalt.Length);
                    userRegistrationRequest.User.PasswordSalt = saltKey;
                    userRegistrationRequest.User.Password = encryptionService.CreatePasswordHash(userRegistrationRequest.Password, saltKey, _membershipSettings.HashedPasswordFormat);

                    break;
            }

            if(string.IsNullOrEmpty(userRegistrationRequest.BlockTypeSystemName))
                userRegistrationRequest.User.CurrentBlockType = null;
            else {
                var blockTypeService = EngineContext.Current.Resolve<IDbService<BlockType, BlockTypeQuery>>();

                var blockType = blockTypeService.GetBySystemName(userRegistrationRequest.BlockTypeSystemName);
            }

            var roleService = EngineContext.Current.Resolve<IDbService<Role, RoleQuery>>();

            var registeredRole = roleService.GetBySystemName(RoleNames.Registered);

            if (registeredRole == null)
                result.AddResourceError(RoleConstants.Messages.RegistetedRoleNotFound);
            else
                userRegistrationRequest.User.Roles.Add(registeredRole);

            var guestRole = userRegistrationRequest.User.Roles.FirstOrDefault(r => r.SystemName == RoleNames.Guests);

            if (guestRole != null)
                userRegistrationRequest.User.Roles.Remove(guestRole);

            service.Save(userRegistrationRequest.User);

            return result;
        }

        public ServiceOperationResult ChangePassword(ChangePasswordRequest changePasswordRequest) {
            var result = EngineContext.Current.Resolve<ServiceOperationResult>();

            if (changePasswordRequest == null) {
                result.AddResourceError(CommonConstants.Messages.NullEntity);
                return result;
            }

            User user;
            if ((user = GetUserByEmail(changePasswordRequest.Email)) == null) {
                result.AddResourceError(CommonConstants.Messages.UnknownEntity);
                return result;
            }

            var requestIsValid = false;

            if (changePasswordRequest.ValidateRequest) {
                string oldPassword;
                switch (user.PasswordFormat) {
                    case PasswordStoringFormat.Encrypted:
                        oldPassword = _encryptionService.EncryptText(changePasswordRequest.OldPassword);
                        break;
                    case PasswordStoringFormat.Hashed:
                        oldPassword = _encryptionService.CreatePasswordHash(changePasswordRequest.OldPassword, user.PasswordSalt, _membershipSettings.HashedPasswordFormat);
                        break;
                    default:
                        oldPassword = changePasswordRequest.OldPassword;
                        break;
                }

                var oldPasswordIsValid = oldPassword == user.Password;

                if (!oldPasswordIsValid)
                    result.AddResourceError(UserConstants.Messages.InvalidOldPassword);

                if (oldPasswordIsValid)
                    requestIsValid = true;
            } else
                requestIsValid = true;

            if (requestIsValid) {
                switch (changePasswordRequest.NewPasswordFormat) {
                    case PasswordStoringFormat.Clear:
                        user.Password = changePasswordRequest.NewPassword;
                        break;
                    case PasswordStoringFormat.Encrypted:
                        user.Password = _encryptionService.EncryptText(changePasswordRequest.NewPassword);
                        break;
                    case PasswordStoringFormat.Hashed:
                        var saltKey = _encryptionService.CreateSaltKey(UserConstants.Fields.Password.Length);
                        user.PasswordSalt = saltKey;
                        user.Password = _encryptionService.CreatePasswordHash(changePasswordRequest.NewPassword, saltKey, _membershipSettings.HashedPasswordFormat);
                        break;
                }

                user.PasswordFormat = changePasswordRequest.NewPasswordFormat;

                result.CopyFrom(UpdateUser(user));
            }

            return result;
        }

        public ServiceOperationResult SetEmail(User user, string newEmail) {
            var result = EngineContext.Current.Resolve<ServiceOperationResult>();

            if (user == null) {
                result.AddResourceError(CommonConstants.Systematic.NullEntity);
                return result;
            }

            if (!result.Success)
                return result;

            var oldEmail = user.Email;

            user.Email = newEmail;

            result.CopyFrom(UpdateUser(user));

            if (!result.Success)
                return result;

            if (!string.IsNullOrEmpty(oldEmail) && !oldEmail.Equals(newEmail, StringComparison.InvariantCultureIgnoreCase)) {
                var subscriptionOld = _newsletterSubscriptionsService.GetNewsletterSubscriptionByEmail(oldEmail);
                if (subscriptionOld != null) {
                    subscriptionOld.Email = newEmail;
                    _newsletterSubscriptionsService.UpdateNewsletterSubscription(subscriptionOld);
                }
            }

            return result;
        }

        public ServiceOperationResult SetUserName(User user, string newUserName) {
            var result = EngineContext.Current.Resolve<ServiceOperationResult>();

            if (user == null) {
                result.AddResourceError(CommonConstants.Systematic.NullEntity);
                return result;
            }

            if (!_membershipSettings.UserNamesEnabled) {
                result.AddResourceError(UserConstants.Systematic.UserNameDisabled);
                return result;
            }

            if (!_membershipSettings.AllowUsersToChangeUserNames) {
                result.AddResourceError(UserConstants.Systematic.ChangingUserNameNotAllowed);
                return result;
            }

            user.UserName = newUserName;

            result.CopyFrom(UpdateUser(user));

            return result;
        }

        public User GetOrInsertGuestUser() {
            var guestUser = QueryUsers(u => u.Roles.Any(r => r.SystematicName == RoleNames.Guests)).FirstOrDefault();

            if (guestUser != null)
                return guestUser;

            var randomEmail = string.Format("guest-{0}@faramedia.com", CommonHelper.GenerateRandomDigitCode(5));

            guestUser = new User {
                IsPublished = true,
                Email = randomEmail,
                Password = randomEmail,
                LastActivityDateUtc = DateTime.UtcNow
            };

            var guestRole = _roleService.GetRoleBySystemName(RoleNames.Guests);

            if (guestRole == null)
                throw new FaraException("Guest role not found.");

            guestUser.Roles.Add(guestRole);

            InsertUser(guestUser);

            return guestUser;
        }

        public static ServiceOperationResultWithValue<int> DeleteGuestUsers(this IDbService<User, UserQuery> service, DateTime? registrationFrom, DateTime? registrationTo) {
            var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<int>>();

            var users = service.GetAll(uq => uq.WithRoleSystemName(RoleNames.Guests).WithIsSecured(false).WithRegisterDateUtcBetween(registrationFrom, registrationTo));

            var numberOfDeletedUsers = 0;
            foreach (var user in users) {
                service.Delete(user);

                numberOfDeletedUsers++;
            }

            return result.With(numberOfDeletedUsers);
        }
    }
}