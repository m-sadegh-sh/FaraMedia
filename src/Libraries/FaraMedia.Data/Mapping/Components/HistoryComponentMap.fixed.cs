namespace FaraMedia.Data.Mapping.Components {
	using FaraMedia.Core.Domain.Components;

	using NHibernate.Mapping.ByCode.Conformist;

	public sealed class HistoryComponentMap : ComponentMapping<HistoryComponent> {
		public HistoryComponentMap() {
			ManyToOne(hc => hc.Invoker);
			Property(hc => hc.InvokerIp);
			Property(hc => hc.InvokeDateUtc);
		}
	}
}