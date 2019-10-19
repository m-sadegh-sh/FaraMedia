namespace FaraMedia.Core.Domain.Fundamentals {
	using System;

	using Iesi.Collections.Generic;

	public class Album : UIElementBase {
		private ISet<Track> _tracks;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual DateTime ReleaseDateUtc { get; set; }

		public virtual ISet<Track> Tracks {
			get { return _tracks ?? (_tracks = new HashedSet<Track>()); }
			protected set { _tracks = value; }
		}
	}
}