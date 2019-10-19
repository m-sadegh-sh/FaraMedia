namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ToDoInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ToDoConstants.Fields.Title.Label, "عنوان");
                NewResource(ToDoConstants.Fields.Description.Label, "توضیحات");

                NewResource(ToDoConstants.Fields.Performer.Label, "انجام دهنده");
                NewResource(ToDoConstants.Fields.Status.Label, "وضعیت");

                NewResource(ToDoConstants.Fields.DueDateUtc.Label, "تاریخ انجام");

                transaction.Commit();
            }
        }
    }
}