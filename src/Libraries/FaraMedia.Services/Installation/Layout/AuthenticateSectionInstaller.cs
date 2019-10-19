namespace FaraMedia.Services.Installation.Layout {
    using FaraMedia.Data.Schemas.Authenticate;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class AuthenticateSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(AuthenticateSectionConstants.Metadata.Title, "تصدیق هویت");

                NewResource(AuthenticateSectionConstants.SignController.In.Metadata.Title, "ورود به حساب کاربری");
                NewResource(AuthenticateSectionConstants.SignController.In.Metadata.Description, "کاربر گرامی برای دسترسی به بخش های مختلف لازم است با وارد کردن اطلاعات مورد نظر در فرم روبرو، اقدام به ورود به حساب کاربری خود نمائید.");
                NewResource(AuthenticateSectionConstants.SignController.In.Messages.SignedIn, "با موفقیت به حساب خود وارد شدید.");
                NewResource(AuthenticateSectionConstants.SignController.In.Commands.SignIn, "ورود");
                NewResource(AuthenticateSectionConstants.SignController.In.Fields.RememberMe.Label, "من را بیاد داشته باش. (اگر از طریق یک محیط عمومی (مثلا کافی نت) اقدام به ورود می کنید پیشنهاد می شود این گرینه انتخاب نشود.)");

                NewResource(AuthenticateSectionConstants.SignController.Out.Messages.SignedOut, "با موفقیت از حساب خود خارج شدید.");
                NewResource(AuthenticateSectionConstants.SignController.Out.Commands.SignOut, "خروج");

                transaction.Commit();
            }
        }
    }
}