namespace FaraMedia.Services.Installation.Security {
    using System;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Configuration;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;
    using FaraMedia.Data.Schemas.Security;
    using FaraMedia.Services.Installation.Abstraction;
    using FaraMedia.Services.Querying.Security;

    using NHibernate;
    using NHibernate.Linq;

    public sealed class UserInstaller : EntityInstallerBase {
        private readonly BootstrapConfig _bootstrapConfig;

        public UserInstaller(BootstrapConfig bootstrapConfig) {
            _bootstrapConfig = bootstrapConfig;
        }

        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(UserConstants.Messages.SearchEngine, "امکان ثبت این کاربر (موتور جستجو) وجود ندارد.");
                NewResource(UserConstants.Messages.AlreadyRegistered, "این کاربر قبلا ثبت شده است.");
                NewResource(UserConstants.Messages.InvalidOldPassword, "گذرواژه قبلی صحیح نمی باشد.");
                NewResource(UserConstants.Messages.UserNameDisabled, "امکان تعیین نام کاربری وجود ندارد.");
                NewResource(UserConstants.Messages.ChangingUserNameNotAllowed, "امکان تغییر نام کاربری وجود ندارد.");
                NewResource(UserConstants.Messages.DeletionSystemAccountNotAllowed, "امکان حذف کاربر سیستمی وجود ندارد.");
                NewResource(UserConstants.Messages.InvalidUserNameOrEmail, "نام کاربری و/یا ایمیل صحیح نمی باشد.");
                NewResource(UserConstants.Messages.InvalidUserNameEmailOrPassword, "نام کاربری/ایمیل و/یا گذرواژه صحیح نمی باشد.");
                NewResource(UserConstants.Messages.YourAccountIsNotValid, "حساب کاربری مورد نظر مجاز نمی باشد.");
                NewResource(UserConstants.Messages.YourAccountIsNotActivatedYet, "حساب کاربری شما هنور فعال نشده است.");
                NewResource(UserConstants.Messages.YourAccountWasBlocked, "حساب کاربری شما مسدود شده است.");
                
                NewResource(UserConstants.Fields.SystemName.Label, "نام سیستمی");
                NewResource(UserConstants.Fields.UserName.Label, "نام کاربری");
                NewResource(UserConstants.Fields.Email.Label, "پست الکترونیکی");
                NewResource(UserConstants.Fields.Password.Label, "گذرواژه");
                NewResource(UserConstants.Fields.PasswordFormat.Label, "قالب گذرواژه");
                NewResource(UserConstants.Fields.PasswordFormat.Clear, "معمولی");
                NewResource(UserConstants.Fields.PasswordFormat.Hashed, "هش شده (غیر قابل بازگشت)");
                NewResource(UserConstants.Fields.PasswordFormat.Encrypted, "رمز نگاری شده");

                NewResource(UserConstants.Fields.LastLoginDateUtc.Label, "تاریخ آخرین ورود");
                NewResource(UserConstants.Fields.LastActivityDateUtc.Label, "تاریخ آخرین فعالیت");
                NewResource(UserConstants.Fields.AdminComment.Label, "توضیحات (مدیر)");
                NewResource(UserConstants.Fields.LastIpAddress.Label, "آخرین آدرس آی پی");

                NewResource(UserConstants.Fields.CurrentBlockType.Label, "جلوگیری از خرید");

                NewResource(UserConstants.Fields.Roles.Label, "نام سیستمی");
                NewResource(UserConstants.Fields.Activities.Label, "نام کاربری");
                NewResource(UserConstants.Fields.Logs.Label, "پست الکترونیکی");
                NewResource(UserConstants.Fields.ToDos.Label, "گذرواژه");
                NewResource(UserConstants.Fields.Tickets.Label, "توضیحات (مدیر)");
                NewResource(UserConstants.Fields.Responses.Label, "آخرین آدرس آی پی");
                NewResource(UserConstants.Fields.IncomingFriendRequests.Label, "توضیحات (مدیر)");
                NewResource(UserConstants.Fields.OutgoingFriendRequests.Label, "آخرین آدرس آی پی");
                NewResource(UserConstants.Fields.Blogs.Label, "توضیحات (مدیر)");
                NewResource(UserConstants.Fields.Orders.Label, "آخرین آدرس آی پی");
                NewResource(UserConstants.Fields.Likes.Label, "توضیحات (مدیر)");
                NewResource(UserConstants.Fields.Shares.Label, "آخرین آدرس آی پی");
                NewResource(UserConstants.Fields.VotingRecords.Label, "آخرین آدرس آی پی");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                var roles = session.Query<Role>().ToList();

                var userService = EngineContext.Current.Resolve<IDbService<User, UserQuery>>();

                var searchEngine = new User {
                    IsSecured = true,
                    PasswordFormat = PasswordStoringFormat.Clear,
                    LastActivityDateUtc = DateTime.UtcNow,
                    SystemName = UserNames.SearchEngine,
                    Password = CommonHelper.GenerateRandomMixedString(UserConstants.Fields.Password.Length),
                    Email = "builtin@faramedia.com",
                    AdminComment = "کاربر توکار برای پردازش درخواست های ارسال شده از طرف موتورهای جستجو."
                };

                searchEngine.Roles.Add(roles.ElementAt(2));

                session.Insert(searchEngine);

                var admin = new User {
                    PasswordFormat = PasswordStoringFormat.Clear,
                    LastActivityDateUtc = DateTime.UtcNow,
                    UserName = _bootstrapConfig.UserName,
                    Password = _bootstrapConfig.Password,
                    Email = _bootstrapConfig.Email,
                };

                admin.Roles.AddAll(roles.Where(r => r.SystemName != RoleNames.Guests).ToList());

                session.Insert(admin);

                session.Insert(new EntityAttribute {
                    Key = UserAttributeNames.FirstName,
                    Value = "محمدصادق",
                    OwnerId = admin.Id
                });
                session.Insert(new EntityAttribute {
                    Key = UserAttributeNames.LastName,
                    Value = "شاد",
                    OwnerId = admin.Id
                });

                userService.ChangePassword(new ChangePasswordRequest(_bootstrapConfig.Email, false, UserConstants.Fields.PasswordFormat.Hashed, _bootstrapConfig.Password));

                transaction.Commit();
            }
        }
    }
}