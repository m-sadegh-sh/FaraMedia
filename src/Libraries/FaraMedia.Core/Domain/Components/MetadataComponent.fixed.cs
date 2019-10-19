namespace FaraMedia.Core.Domain.Components {
	using FaraMedia.Core.Sanitization;

	public class MetadataComponent : IComponent {
		private string _slug;

		public virtual string Title { get; set; }

		public virtual string Slug {
			get { return _slug; }
			set { _slug = value.Sanitize(); }
		}

		public virtual string Keywords { get; set; }
		public virtual string Description { get; set; }

		public void SecondaryCandidateSlug(string suggestedSlug) {
			if (string.IsNullOrWhiteSpace(Slug))
				Slug = suggestedSlug;
		}
	}
}