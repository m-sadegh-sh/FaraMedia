namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class TrackInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(TrackConstants.Fields.Title.Label, "عنوان");
                NewResource(TrackConstants.Fields.Description.Label, "توضیحات");

                NewResource(TrackConstants.Fields.IsVideo.Label, "تصویری");
                NewResource(TrackConstants.Fields.TrackNumber.Label, "شماره قطعه");
                NewResource(TrackConstants.Fields.ReleaseDateUtc.Label, "تاریخ انتشار");

                NewResource(TrackConstants.Fields.Genre.Label, "سبک");
                NewResource(TrackConstants.Fields.Album.Label, "آلبوم");
                NewResource(TrackConstants.Fields.Publisher.Label, "ناشر");

                NewResource(TrackConstants.Fields.Covers.Label, "سبک");
                NewResource(TrackConstants.Fields.Downloads.Label, "آلبوم");
                NewResource(TrackConstants.Fields.Singers.Label, "ناشر");
                NewResource(TrackConstants.Fields.Composers.Label, "سبک");
                NewResource(TrackConstants.Fields.Arrangementers.Label, "آلبوم");
                NewResource(TrackConstants.Fields.Songwriters.Label, "ناشر");

                transaction.Commit();
            }
        }
    }
}