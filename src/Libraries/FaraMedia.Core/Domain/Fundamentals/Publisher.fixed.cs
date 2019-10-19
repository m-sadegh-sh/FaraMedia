namespace FaraMedia.Core.Domain.Fundamentals {
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Misc;

	using Iesi.Collections.Generic;

	public class Publisher : UIElementBase {
		private ISet<Track> _tracks;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Name);
		}

		public virtual string Name { get; set; }
		public virtual string Ceo { get; set; }
		public virtual string RegisterationNumber { get; set; }
		public virtual string Email { get; set; }
		public virtual string BriefHistory { get; set; }
		public virtual Redirector Website { get; set; }
		public virtual Picture Logo { get; set; }

		public virtual ISet<Track> Tracks {
			get { return _tracks ?? (_tracks = new HashedSet<Track>()); }
			protected set { _tracks = value; }
		}
	}
}