namespace FaraMedia.Data.Schemas.Layout {
    public class ComponentModelConstants : ConstantsBase {
        public static class MetadataComponentModel {
            public class Metadata {
                public static readonly string Title = Helpers.Key<Metadata>(m => Title);
                public static readonly string Description = Helpers.Key<Metadata>(m => Description);
            }
        }
    }
}