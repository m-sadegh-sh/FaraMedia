namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class TicketStatusInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(TicketStatusConstants.Fields.SystemName.Label, "پاسخ دهنده");
                NewResource(TicketStatusConstants.Fields.DisplayName.Label, "پاسخ دهنده");
                NewResource(TicketStatusConstants.Fields.Description.Label, "پاسخ دهنده");

                NewResource(TicketStatusConstants.Fields.Tickets.Label, "پاسخ دهنده");

                transaction.Commit();
            }
        }
    }
}