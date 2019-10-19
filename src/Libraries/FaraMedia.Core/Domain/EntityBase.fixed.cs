namespace FaraMedia.Core.Domain {
	public abstract class EntityBase : IEntity {
		public virtual long Id { get; set; }

		public override bool Equals(object obj) {
			return Equals(obj as EntityBase);
		}

		public virtual bool IsTransient() {
			return IsTransient(this);
		}

		private static bool IsTransient(EntityBase obj) {
			return obj != null && Equals(obj.Id,
			                             default(long));
		}

		public virtual bool Equals(EntityBase other) {
			if (other == null)
				return false;

			if (ReferenceEquals(this,
			                    other))
				return true;

			if (!IsTransient(this) && !IsTransient(other) && Equals(Id,
			                                                        other.Id)) {
				var otherType = other.GetType();
				var thisType = GetType();
				return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
			}

			return false;
		}

		public override int GetHashCode() {
			if (Equals(Id,
			           default(long)))
				return base.GetHashCode();

			return Id.GetHashCode();
		}

		public static bool operator ==(EntityBase x,
		                               EntityBase y) {
			return Equals(x,
			              y);
		}

		public static bool operator !=(EntityBase x,
		                               EntityBase y) {
			return !Equals(x,
			               y);
		}
	}
}