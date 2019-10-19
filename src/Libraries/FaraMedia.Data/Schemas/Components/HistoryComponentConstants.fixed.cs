namespace FaraMedia.Data.Schemas.Components {
	using FaraMedia.Core.Domain.Components;

	public sealed class HistoryComponentConstants : ConstantsBase<HistoryComponent> {
		public sealed class Fields {
			public sealed class Invoker {
				public static readonly string Label = Helpers.Label<Invoker>();
			}

			public sealed class InvokerIp {
				public const int Length = Constants.IpAddressLength;

				public static readonly string Label = Helpers.Label<InvokerIp>();
			}

			public sealed class InvokeDateUtc {
				public static readonly string Label = Helpers.Label<InvokeDateUtc>();
			}
		}
	}
}