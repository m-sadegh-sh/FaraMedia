namespace FaraMedia.Data.Mapping.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class ArtistMap : UIElementMapBase<Artist> {
		public ArtistMap() {
			Property(a => a.FullName);
			Property(a => a.AlternativeName);
			Property(a => a.HomeTown);
			Property(a => a.Biography);
			Property(a => a.BirthDateUtc);
			ManyToOne(a => a.Facebook);
			ManyToOne(a => a.Avatar);
			Set(a => a.PhotoAlbums);
			SetInverse(a => a.SingedTracks,
			           t => t.Singers);
			SetInverse(a => a.ComposedTracks,
			           t => t.Composers);
			SetInverse(a => a.ArrangedTracks,
			           t => t.Arrangementers);
			SetInverse(a => a.SongwrittenTracks,
			           t => t.Songwriters);
		}
	}
}