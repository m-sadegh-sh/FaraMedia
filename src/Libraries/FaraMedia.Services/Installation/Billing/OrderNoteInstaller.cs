namespace FaraMedia.Services.Installation.Billing {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class OrderNoteInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(OrderNoteConstants.Fields.Note.Label, "یادداشت");

                NewResource(OrderNoteConstants.Fields.IsPublic.Label, "نمایش به سفارش دهنده");

                NewResource(OrderNoteConstants.Fields.Order.Label, "مربوط به");

                transaction.Commit();
            }
        }
    }
}