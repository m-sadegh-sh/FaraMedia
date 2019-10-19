namespace FaraMedia.Core.Domain.Fundamentals {
	using System;

	using FaraMedia.Core.Domain.FileManagement;

	using Iesi.Collections.Generic;

	public class Track : UIElementBase {
		private ISet<Artist> _singers;
		private ISet<Artist> _composers;
		private ISet<Artist> _arrangementers;
		private ISet<Artist> _songwriters;
		private ISet<Picture> _covers;
		private ISet<Download> _downloads;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual bool IsVideo { get; set; }
		public virtual int TrackNumber { get; set; }
		public virtual DateTime ReleaseDateUtc { get; set; }
		public virtual Genre Genre { get; set; }
		public virtual Album Album { get; set; }
		public virtual Publisher Publisher { get; set; }

		public virtual ISet<Picture> Covers {
			get { return _covers ?? (_covers = new HashedSet<Picture>()); }
			protected set { _covers = value; }
		}

		public virtual ISet<Download> Downloads {
			get { return _downloads ?? (_downloads = new HashedSet<Download>()); }
			protected set { _downloads = value; }
		}

		public virtual ISet<Artist> Singers {
			get { return _singers ?? (_singers = new HashedSet<Artist>()); }
			protected set { _singers = value; }
		}

		public virtual ISet<Artist> Composers {
			get { return _composers ?? (_composers = new HashedSet<Artist>()); }
			protected set { _composers = value; }
		}

		public virtual ISet<Artist> Arrangementers {
			get { return _arrangementers ?? (_arrangementers = new HashedSet<Artist>()); }
			protected set { _arrangementers = value; }
		}

		public virtual ISet<Artist> Songwriters {
			get { return _songwriters ?? (_songwriters = new HashedSet<Artist>()); }
			protected set { _songwriters = value; }
		}
	}
}