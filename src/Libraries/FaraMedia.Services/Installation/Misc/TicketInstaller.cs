namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class TicketInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(TicketConstants.Fields.Opener.Label, "باز شده توسط");
                NewResource(TicketConstants.Fields.OpenDateUtc.Label, "باز شده توسط");

                NewResource(TicketConstants.Fields.Subject.Label, "موضوع");
                NewResource(TicketConstants.Fields.Body.Label, "توضیحات");

                NewResource(TicketConstants.Fields.Department.Label, "بخش");
                NewResource(TicketConstants.Fields.CheckPriority.Label, "اولویت");
                NewResource(TicketConstants.Fields.CheckPriority.Low, "کم");
                NewResource(TicketConstants.Fields.CheckPriority.Medium, "متوسط");
                NewResource(TicketConstants.Fields.CheckPriority.High, "زیاد");
                NewResource(TicketConstants.Fields.Status.Label, "وضعیت");

                NewResource(TicketConstants.Fields.Responses.Label, "وضعیت");

                transaction.Commit();
            }
        }
    }
}