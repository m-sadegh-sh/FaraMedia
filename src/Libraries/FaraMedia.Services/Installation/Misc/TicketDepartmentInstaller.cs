namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class TicketDepartmentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(TicketDepartmentConstants.Fields.SystemName.Label, "عنوان");
                NewResource(TicketDepartmentConstants.Fields.DisplayName.Label, "عنوان");
                NewResource(TicketDepartmentConstants.Fields.Description.Label, "توضیحات");

                NewResource(TicketDepartmentConstants.Fields.Tickets.Label, "وضعیت");

                transaction.Commit();
            }
        }
    }
}