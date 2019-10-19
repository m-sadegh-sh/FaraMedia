namespace FaraMedia.Core.Domain.Misc {
	using FaraMedia.Core.Domain.FileManagement;
	using FaraMedia.Core.Domain.Fundamentals;
	using FaraMedia.Core.Sanitization;

	using Iesi.Collections.Generic;

	public class Redirector : EntityBase {
		private string _urlName;

		private ISet<Download> _downloads;
		private ISet<Artist> _artists;
		private ISet<Publisher> _publishers;

		public virtual string TargetUrl { get; set; }

		public virtual string ShortHash { get; set; }

		public virtual string UrlName {
			get { return _urlName; }
			set { _urlName = value.Sanitize(); }
		}

		public virtual string Description { get; set; }

		public virtual int UsageTimes { get; set; }

		public virtual ISet<Download> Downloads {
			get { return _downloads ?? (_downloads = new HashedSet<Download>()); }
			protected set { _downloads = value; }
		}

		public virtual ISet<Artist> Artists {
			get { return _artists ?? (_artists = new HashedSet<Artist>()); }
			protected set { _artists = value; }
		}

		public virtual ISet<Publisher> Publishers {
			get { return _publishers ?? (_publishers = new HashedSet<Publisher>()); }
			protected set { _publishers = value; }
		}
	}
}