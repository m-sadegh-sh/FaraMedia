namespace FaraMedia.Services.Installation.Layout {
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ControlHelpersInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ControlHelpersConstants.Pager.Labels.Previous, "→ قبلی");
                NewResource(ControlHelpersConstants.Pager.Labels.Next, "بعدی ←");
                NewResource(ControlHelpersConstants.Pager.Texts.Format, "نمایش {0} - {1} از {2}");
                NewResource(ControlHelpersConstants.Pager.Texts.SingleFormat, "نمایش {0} - {1}");

                transaction.Commit();
            }
        }
    }
}