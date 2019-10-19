namespace FaraMedia.Services.Installation.Components {
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ModificationHistoryComponentInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ModificationHistoryComponentConstants.Fields.IsModified.Label, "عنوان");

                NewResource(ModificationHistoryComponentConstants.Fields.LastModifier.Label, "عنوان");
                NewResource(ModificationHistoryComponentConstants.Fields.LastModifierIp.Label, "عنوان");

                NewResource(ModificationHistoryComponentConstants.Fields.LastModifyDateUtc.Label, "عنوان");

                transaction.Commit();
            }
        }
    }
}