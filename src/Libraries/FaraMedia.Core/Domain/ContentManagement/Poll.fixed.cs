namespace FaraMedia.Core.Domain.ContentManagement {
	using System;

	using Iesi.Collections.Generic;

	public class Poll : UIElementBase {
		private ISet<PollChoice> _choices;

		public override void OverrideMetadata() {
			Metadata.SecondaryCandidateSlug(Title);
		}

		public virtual string PlaceholderKey { get; set; }
		public virtual string Title { get; set; }
		public virtual string Description { get; set; }
		public virtual DateTime? StartDateUtc { get; set; }
		public virtual DateTime? EndDateUtc { get; set; }
		public virtual bool AuthenticationRequired { get; set; }
		public virtual bool ShowOnHomePage { get; set; }

		public virtual ISet<PollChoice> Choices {
			get { return _choices ?? (_choices = new HashedSet<PollChoice>()); }
			protected set { _choices = value; }
		}
	}
}