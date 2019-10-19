namespace FaraMedia.Services.Extensions.Billing {
	using System;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Services.Querying.Billing;

	public static class OrderServiceExtensions {
		public static Order GetByGuid(this IDbService<Order, OrderQuery> service,
		                              Guid guid) {
			if (Neutrals.Is(guid))
				return null;

			var order = service.Get(oq => oq.WithGuid(guid));

			return order;
		}
	}
}