namespace FaraMedia.Services.Querying.Security {
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class BlockReasonQuery : AttributeQueryBase<BlockReason, BlockReasonQuery> {
		public BlockReasonQuery(IEnumerable<BlockReason> entities) : base(entities) {}

		public BlockReasonQuery(IQueryable<BlockReason> entities) : base(entities) {}

		public BlockReasonQuery WithUser(User value = null,
		                                 ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                 CollectionOperator @operator = CollectionOperator.Equal,
		                                 CollectionDirection direction = CollectionDirection.Any) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case CollectionOperator.Equal:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(br => br.Users.Any(u => u == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(br => br.Users.All(u => u == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(br => br.Users.Any(u => u != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(br => br.Users.All(u => u != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BlockReasonQuery WithUserId(long? value = null,
		                                   ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                   CollectionOperator @operator = CollectionOperator.Equal,
		                                   CollectionDirection direction = CollectionDirection.Any) {
			switch (mode) {
				case ArgumentEvaluationMode.IgnoreNeutral:
					if (Neutrals.Is(value))
						return this;
					break;

				case ArgumentEvaluationMode.Explicit:
					break;

				default:
					throw new NotSupportedEnumException(mode);
			}

			switch (@operator) {
				case CollectionOperator.Equal:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(br => br.Users.Any(u => u.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(br => br.Users.All(u => u.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(br => br.Users.Any(u => u.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(br => br.Users.All(u => u.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}
	}
}