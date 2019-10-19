namespace FaraMedia.Services.Installation.ContentManagement {
    using FaraMedia.Data.Schemas.ContentManagement;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class PollInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(PollConstants.Fields.PlaceholderKey.Label, "عنوان");
                NewResource(PollConstants.Fields.Title.Label, "عنوان");
                NewResource(PollConstants.Fields.Description.Label, "توضیحات");

                NewResource(PollConstants.Fields.StartDateUtc.Label, "تاریخ شروع");
                NewResource(PollConstants.Fields.EndDateUtc.Label, "تاریخ پایان");

                NewResource(PollConstants.Fields.AuthenticationRequired.Label, "نمایش در صفحه اصلی");
                NewResource(PollConstants.Fields.ShowOnHomePage.Label, "نمایش در صفحه اصلی");

                NewResource(PollConstants.Fields.Choices.Label, "نمایش در صفحه اصلی");

                transaction.Commit();
            }
        }
    }
}