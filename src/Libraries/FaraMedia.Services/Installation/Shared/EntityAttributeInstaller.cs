namespace FaraMedia.Services.Installation.Shared {
    using FaraMedia.Data.Schemas.Shared;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class EntityAttributeInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                NewResource(EntityAttributeConstants.Messages.NotSupportedValueType, "نوع مورد نظر پشتیبانی نمی شود");
                NewResource(EntityAttributeConstants.Messages.InvalidOwnerId, "نوع مورد نظر پشتیبانی نمی شود");

                NewResource(EntityAttributeConstants.Fields.Key.Label, "کلید");
                NewResource(EntityAttributeConstants.Fields.DisplayName.Label, "کلید");
                NewResource(EntityAttributeConstants.Fields.Value.Label, "مقدار");
                NewResource(EntityAttributeConstants.Fields.Description.Label, "کلید");

                transaction.Commit();
            }
        }
    }
}