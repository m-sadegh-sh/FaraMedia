namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class LanguageInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(LanguageConstants.Fields.SystemName.Label, "نام");
                NewResource(LanguageConstants.Fields.DisplayName.Label, "نام");
                NewResource(LanguageConstants.Fields.Description.Label, "نام");

                NewResource(LanguageConstants.Fields.CultureCode.Label, "آدرس ایمیل");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                session.Insert(new Language {
                    SystemName = "FA",
                    DisplayName = "Persian",
                    NativeName = "فارسی",
                    CultureCode = "fa"
                });

                transaction.Commit();
            }
        }
    }
}