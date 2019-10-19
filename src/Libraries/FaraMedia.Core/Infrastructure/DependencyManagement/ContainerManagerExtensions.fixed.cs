namespace FaraMedia.Core.Infrastructure.DependencyManagement {
	using System.Web;

	using Autofac.Builder;
	using Autofac.Integration.Mvc;

	public static class ContainerManagerExtensions {
		public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> PerLifeStyle<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder,
		                                                                                                                                        ComponentLifeStyle lifeStyle) {
			switch (lifeStyle) {
				case ComponentLifeStyle.LifetimeScope:
					return HttpContext.Current != null ? builder.InstancePerHttpRequest() : builder.InstancePerLifetimeScope();

				case ComponentLifeStyle.Transient:
					return builder.InstancePerDependency();

				case ComponentLifeStyle.Singleton:
					return builder.SingleInstance();

				default:
					throw new NotSupportedEnumException(lifeStyle);
			}
		}
	}
}