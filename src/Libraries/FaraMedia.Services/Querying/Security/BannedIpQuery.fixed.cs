namespace FaraMedia.Services.Querying.Security {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Operators;

	public sealed class BannedIpQuery : EntityQueryBase<BannedIp, BannedIpQuery> {
		public BannedIpQuery(IEnumerable<BannedIp> entities) : base(entities) {}

		public BannedIpQuery(IQueryable<BannedIp> entities) : base(entities) {}

		public BannedIpQuery WithIpAddress(string value = null,
		                                   ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                   StringOperator @operator = StringOperator.Exact,
		                                   StringDirection direction = StringDirection.SourceToExpected) {
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
				case StringOperator.Exact:
					switch (direction) {
						case StringDirection.SourceToExpected:
						case StringDirection.ExpectedToSource:
						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.IpAdrress == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(bi => bi.IpAdrress.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(bi => value.Contains(bi.IpAdrress));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.IpAdrress.Contains(value) || value.Contains(bi.IpAdrress));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(bi => bi.IpAdrress.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(bi => value.StartsWith(bi.IpAdrress));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.IpAdrress.StartsWith(value) || value.StartsWith(bi.IpAdrress));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(bi => bi.IpAdrress.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(bi => value.EndsWith(bi.IpAdrress));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.IpAdrress.EndsWith(value) || value.EndsWith(bi.IpAdrress));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BannedIpQuery WithReason(string value = null,
		                                ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                StringOperator @operator = StringOperator.Exact,
		                                StringDirection direction = StringDirection.SourceToExpected) {
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
				case StringOperator.Exact:
					switch (direction) {
						case StringDirection.SourceToExpected:
						case StringDirection.ExpectedToSource:
						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.Reason == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(bi => bi.Reason.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(bi => value.Contains(bi.Reason));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.Reason.Contains(value) || value.Contains(bi.Reason));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(bi => bi.Reason.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(bi => value.StartsWith(bi.Reason));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.Reason.StartsWith(value) || value.StartsWith(bi.Reason));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(bi => bi.Reason.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(bi => value.EndsWith(bi.Reason));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(bi => bi.Reason.EndsWith(value) || value.EndsWith(bi.Reason));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BannedIpQuery WithStartDateUtc(DateTime? value = null,
		                                      ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                      IntegralOperator @operator = IntegralOperator.Equal) {
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
				case IntegralOperator.Equal:
					Entities = Entities.Where(bi => bi.StartDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(bi => bi.StartDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(bi => bi.StartDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(bi => bi.StartDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(bi => bi.StartDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(bi => bi.StartDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BannedIpQuery WithStartDateUtcBetween(DateTime? from = null,
		                                             ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             DateTime? to = null,
		                                             ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(bi => bi.StartDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.StartDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(bi => bi.StartDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.StartDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(bi => bi.StartDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.StartDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(bi => bi.StartDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.StartDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return this;
		}

		public BannedIpQuery WithExpireDateUtc(DateTime? value = null,
		                                       ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                       IntegralOperator @operator = IntegralOperator.Equal) {
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
				case IntegralOperator.Equal:
					Entities = Entities.Where(bi => bi.ExpireDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(bi => bi.ExpireDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(bi => bi.ExpireDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(bi => bi.ExpireDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(bi => bi.ExpireDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(bi => bi.ExpireDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public BannedIpQuery WithExpireDateUtcBetween(DateTime? from = null,
		                                              ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                              DateTime? to = null,
		                                              ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                              RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(bi => bi.ExpireDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.ExpireDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(bi => bi.ExpireDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.ExpireDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(bi => bi.ExpireDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.ExpireDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(bi => bi.ExpireDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(bi => bi.ExpireDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				default:
					throw new NotSupportedEnumException(@operator);
			}

			return this;
		}
	}
}