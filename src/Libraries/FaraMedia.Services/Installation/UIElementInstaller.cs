namespace FaraMedia.Services.Installation {
    using FaraMedia.Core.Domain;
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class UIElementInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(UIElementConstantsBase<UIElementBase>.Fields.DisplayOrder.Label, "آدرس آی پی");

                NewResource(UIElementConstantsBase<UIElementBase>.Fields.Owner.Label, "تاریخ انتشار");

                NewResource(UIElementConstantsBase<UIElementBase>.Fields.DeletionHistory.Label, "آدرس آی پی");

                transaction.Commit();
            }
        }
    }
}