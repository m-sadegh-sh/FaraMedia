namespace FaraMedia.Services.Installation.Layout {
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class MappingInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(MappingConstants.Texts.False, "خیر");
                NewResource(MappingConstants.Texts.True, "بله");
                NewResource(MappingConstants.Texts.Empty, "نامشخص");

                NewResource(MappingConstants.Texts.Day, "روز");
                NewResource(MappingConstants.Texts.Month, "ماه");
                NewResource(MappingConstants.Texts.Year, "سال");

                transaction.Commit();
            }
        }
    }
}