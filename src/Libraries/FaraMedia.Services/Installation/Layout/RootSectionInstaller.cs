namespace FaraMedia.Services.Installation.Layout {
    using FaraMedia.Data.Schemas.Root;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class RootSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(RootSectionConstants.Metadata.Title, "فرامدیا");
                NewResource(RootSectionConstants.Metadata.Description, "پنل مدیریت");

                NewResource(RootSectionConstants.CommonController.Home.Metadata.Title, "خانه");
                NewResource(RootSectionConstants.CommonController.Home.Commands.Home, "خانه");

                NewResource(RootSectionConstants.ErrorsController.GenericError.Metadata.Title, "خطا در پردازش درخواست :(");
                NewResource(RootSectionConstants.ErrorsController.GenericError.Metadata.Description, "کاربر گرامی، در حین <a href=\"{0}\">پردازش درخواست شما</a> مشکلی پیش آمده است. با عرض پوزش، تیم توسعه هرچه سریعتر اقدامات لازم جهت رفع مشکل پیش آمده را مبذول خواهد داشت. شما می توانید درخواست خود را مجددا ارسال کرده و یا مراتب را از طریق صفحه تماس با ما درمیان بگذارید.");
                NewResource(RootSectionConstants.ErrorsController.NotFound.Metadata.Title, "آدرس درخواستی یافت نشد :(");
                NewResource(RootSectionConstants.ErrorsController.NotFound.Metadata.Description, "کاربر گرامی، <a href=\"{0}\">آدرس درخواستی شما</a> یافت نشد. لطفا آدرس واردشده را مجددا بررسی کرده و در صورت اطمینان، مراتب را از طریق صفحه تماس با ما درمیان بگذارید.");
                NewResource(RootSectionConstants.ErrorsController.AccessDenied.Metadata.Title, "امکان دسترسی به آدرس درخواستی وجود ندارد :(");
                NewResource(RootSectionConstants.ErrorsController.AccessDenied.Metadata.Description, "کاربر گرامی امکان دسترسی به <a href=\"{0}\">آدرس درخواستی شما</a> وجود ندارد.");
                NewResource(RootSectionConstants.ErrorsController.AppClosed.Metadata.Title, "فرامدیا در حال حاضر قادر به سرویس دهی نمی باشد :(");
                NewResource(RootSectionConstants.ErrorsController.AppClosed.Metadata.Description, "کاربر گرامی در حال حاضر امکان سرویس دهی وجود ندارد. لطفا پس از مدتی مجددا اقدام به ارسال درخواست خود نمائید.");

                NewResource(RootSectionConstants.MaintenanceController.Metadata.Title, "نگهداری");
                NewResource(RootSectionConstants.MaintenanceController.ClearCache.Metadata.Title, "پاک کردن کش");
                NewResource(RootSectionConstants.MaintenanceController.RecoverDefaults.Metadata.Title, "بازیابی پیشفرض ها");
                NewResource(RootSectionConstants.MaintenanceController.RestartApplication.Metadata.Title, "راه اندازی مجدد");

                transaction.Commit();
            }
        }
    }
}