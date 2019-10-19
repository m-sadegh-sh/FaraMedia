namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class ToDoStatusInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(ToDoStatusConstants.Fields.SystemName.Label, "پاسخ دهنده");
                NewResource(ToDoStatusConstants.Fields.DisplayName.Label, "پاسخ دهنده");
                NewResource(ToDoStatusConstants.Fields.Description.Label, "پاسخ دهنده");

                NewResource(ToDoStatusConstants.Fields.ToDos.Label, "پاسخ دهنده");

                transaction.Commit();
            }
        }
    }
}