namespace FaraMedia.Core.Patterns {
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;

	public sealed class Singleton<T> {
		private static T _instance;
		private static readonly IDictionary<Type, object> _instances;

		static Singleton() {
			_instances = new ConcurrentDictionary<Type, object>();
		}

		public static T Instance {
			get { return _instance; }
			set {
				_instance = value;
				Instances[typeof (T)] = value;
			}
		}

		public static IDictionary<Type, object> Instances {
			get { return _instances; }
		}
	}
}