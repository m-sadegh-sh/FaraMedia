namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class TicketResponseInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(TicketResponseConstants.Fields.Responder.Label, "پاسخ دهنده");
                NewResource(TicketResponseConstants.Fields.InResponseTo.Label, "در پاسخ به");

                NewResource(TicketResponseConstants.Fields.ResponseDateUtc.Label, "موضوع");

                NewResource(TicketResponseConstants.Fields.Subject.Label, "موضوع");
                NewResource(TicketResponseConstants.Fields.Body.Label, "توضیحات");

                transaction.Commit();
            }
        }
    }
}