namespace FaraMedia.Core.Domain.Systematic {
	using Iesi.Collections.Generic;

	public class ActivityType : AttributeBase {
		private ISet<Activity> _activities;

		public virtual ISet<Activity> Activities {
			get { return _activities ?? (_activities = new HashedSet<Activity>()); }
			protected set { _activities = value; }
		}
	}
}