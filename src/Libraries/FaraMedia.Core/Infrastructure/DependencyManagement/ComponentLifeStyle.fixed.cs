namespace FaraMedia.Core.Infrastructure.DependencyManagement {
	public enum ComponentLifeStyle : byte {
		Singleton = 1,
		Transient = 2,
		LifetimeScope = 4
	}
}