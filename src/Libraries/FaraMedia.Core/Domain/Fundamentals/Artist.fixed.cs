namespace FaraMedia.Core.Domain.Fundamentals {
	using System;

	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Misc;

	using Iesi.Collections.Generic;

	public class Artist : UIElementBase {
		private ISet<PhotoAlbum> _photoAlbums;
		private ISet<Track> _singedTracks;
		private ISet<Track> _composedTracks;
		private ISet<Track> _arrangedTracks;
		private ISet<Track> _songwrittenTracks;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(FullName);
		}

		public virtual string FullName { get; set; }
		public virtual string AlternativeName { get; set; }
		public virtual string HomeTown { get; set; }
		public virtual string Biography { get; set; }
		public virtual DateTime? BirthDateUtc { get; set; }
		public virtual Redirector Facebook { get; set; }
		public virtual Picture Avatar { get; set; }

		public virtual ISet<PhotoAlbum> PhotoAlbums {
			get { return _photoAlbums ?? (_photoAlbums = new HashedSet<PhotoAlbum>()); }
			protected set { _photoAlbums = value; }
		}

		public virtual ISet<Track> SingedTracks {
			get { return _singedTracks ?? (_singedTracks = new HashedSet<Track>()); }
			protected set { _singedTracks = value; }
		}

		public virtual ISet<Track> ComposedTracks {
			get { return _composedTracks ?? (_composedTracks = new HashedSet<Track>()); }
			protected set { _composedTracks = value; }
		}

		public virtual ISet<Track> ArrangedTracks {
			get { return _arrangedTracks ?? (_arrangedTracks = new HashedSet<Track>()); }
			protected set { _arrangedTracks = value; }
		}

		public virtual ISet<Track> SongwrittenTracks {
			get { return _songwrittenTracks ?? (_songwrittenTracks = new HashedSet<Track>()); }
			protected set { _songwrittenTracks = value; }
		}
	}
}