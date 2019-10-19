namespace FaraMedia.Data.Schemas.ContentManagement {
	using FaraMedia.Core.Domain.ContentManagement;

	public sealed class PollChoiceItemConstants : EntityConstantsBase<PollChoiceItem> {
		public static class CacheKeys {
			public static readonly string Pattern = Helpers.CachePattern();
			public static readonly string ById = Helpers.CacheKey(pci => pci.Id);
		}

		public new sealed class Fields : EntityConstantsBase<PollChoice>.Fields {
			public sealed class Text {
				public const int Length = 100;

				public static readonly string Label = Helpers.Label<Text>();
			}

			public sealed class Choice {
				public static readonly string Label = Helpers.Label<Choice>();
			}

			public sealed class VotingRecords {
				public static readonly string Label = Helpers.Label<VotingRecords>();
			}
		}
	}
}