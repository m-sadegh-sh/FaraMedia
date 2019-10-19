namespace FaraMedia.Services.Installation.Fundamentals {
    using FaraMedia.Data.Schemas.Fundamentals;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class ArtistInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ArtistConstants.Fields.FullName.Label, "نام کامل");
                NewResource(ArtistConstants.Fields.AlternativeName.Label, "نام مستعار");
                NewResource(ArtistConstants.Fields.HomeTown.Label, "شهر محل سکونت");
                NewResource(ArtistConstants.Fields.Biography.Label, "بیوگرافی");

                NewResource(ArtistConstants.Fields.BirthDateUtc.Label, "تاریخ تولد");

                NewResource(ArtistConstants.Fields.Facebook.Label, "آدرس فیسبوک");
                NewResource(ArtistConstants.Fields.Avatar.Label, "آواتار");

                NewResource(ArtistConstants.Fields.PhotoAlbums.Label, "آدرس فیسبوک");
                NewResource(ArtistConstants.Fields.SingedTracks.Label, "آواتار");
                NewResource(ArtistConstants.Fields.ComposedTracks.Label, "آدرس فیسبوک");
                NewResource(ArtistConstants.Fields.ArrangedTracks.Label, "آواتار");
                NewResource(ArtistConstants.Fields.SongwrittenTracks.Label, "آدرس فیسبوک");

                transaction.Commit();
            }
        }
    }
}