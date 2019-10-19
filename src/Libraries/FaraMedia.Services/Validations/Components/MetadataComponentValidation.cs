namespace FaraMedia.Services.Validations.Components {
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Data.Schemas.Components;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class MetadataComponentValidation : ValidationDef<MetadataComponent> {
        public MetadataComponentValidation() {
            Define(mc => mc.Title).MaxLength(MetadataComponentConstants.Fields.Title.Length).WithInvalidLength(MetadataComponentConstants.Fields.Title.Label, MetadataComponentConstants.Fields.Title.Length);
            Define(mc => mc.Slug).MaxLength(MetadataComponentConstants.Fields.Slug.Length).WithInvalidLength(MetadataComponentConstants.Fields.Slug.Label, MetadataComponentConstants.Fields.Slug.Length);
            Define(mc => mc.Keywords).MaxLength(MetadataComponentConstants.Fields.Keywords.Length).WithInvalidLength(MetadataComponentConstants.Fields.Keywords.Label, MetadataComponentConstants.Fields.Keywords.Length);
            Define(mc => mc.Description).MaxLength(MetadataComponentConstants.Fields.Description.Length).WithInvalidLength(MetadataComponentConstants.Fields.Description.Label, MetadataComponentConstants.Fields.Description.Length);
        }
    }
}