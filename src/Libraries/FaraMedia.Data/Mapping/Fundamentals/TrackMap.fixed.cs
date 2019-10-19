namespace FaraMedia.Data.Mapping.Fundamentals {
	using FaraMedia.Core.Domain.Fundamentals;

	public sealed class TrackMap : UIElementMapBase<Track> {
		public TrackMap() {
			Property(t => t.Title);
			Property(t => t.Description);
			Property(t => t.IsVideo);
			Property(t => t.TrackNumber);
			Property(t => t.ReleaseDateUtc);
			ManyToOne(t => t.Genre);
			ManyToOne(t => t.Album);
			ManyToOne(t => t.Publisher);
			SetController(t => t.Downloads);
			SetController(t => t.Covers);
			SetController(t => t.Singers);
			SetController(t => t.Composers);
			SetController(t => t.Arrangementers);
			SetController(t => t.Songwriters);
		}
	}
}