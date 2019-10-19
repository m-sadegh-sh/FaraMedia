namespace FaraMedia.Services.Querying.Security {
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using FaraMedia.Core;
	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Core.Domain.Shared;
	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Core.Operators;

	public sealed class UserQuery : EntityQueryBase<User, UserQuery> {
		public UserQuery(IEnumerable<User> entities) : base(entities) {}

		public UserQuery(IQueryable<User> entities) : base(entities) {}

		public UserQuery WithSystemName(string value = null,
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
							Entities = Entities.Where(u => u.SystemName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.SystemName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.Contains(u.SystemName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.SystemName.Contains(value) || value.Contains(u.SystemName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.SystemName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.StartsWith(u.SystemName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.SystemName.StartsWith(value) || value.StartsWith(u.SystemName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.SystemName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.EndsWith(u.SystemName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.SystemName.EndsWith(value) || value.EndsWith(u.SystemName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithUserName(string value = null,
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
							Entities = Entities.Where(u => u.UserName == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.UserName.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.Contains(u.UserName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.UserName.Contains(value) || value.Contains(u.UserName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.UserName.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.StartsWith(u.UserName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.UserName.StartsWith(value) || value.StartsWith(u.UserName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.UserName.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.EndsWith(u.UserName));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.UserName.EndsWith(value) || value.EndsWith(u.UserName));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithEmail(string value = null,
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
							Entities = Entities.Where(u => u.Email == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.Email.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.Contains(u.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.Email.Contains(value) || value.Contains(u.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.Email.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.StartsWith(u.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.Email.StartsWith(value) || value.StartsWith(u.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.Email.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.EndsWith(u.Email));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.Email.EndsWith(value) || value.EndsWith(u.Email));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithPassword(string value = null,
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
							Entities = Entities.Where(u => u.Password == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.Password.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.Contains(u.Password));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.Password.Contains(value) || value.Contains(u.Password));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.Password.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.StartsWith(u.Password));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.Password.StartsWith(value) || value.StartsWith(u.Password));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.Password.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.EndsWith(u.Password));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.Password.EndsWith(value) || value.EndsWith(u.Password));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithPasswordSalt(string value = null,
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
							Entities = Entities.Where(u => u.PasswordSalt == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.PasswordSalt.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.Contains(u.PasswordSalt));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.PasswordSalt.Contains(value) || value.Contains(u.PasswordSalt));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.PasswordSalt.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.StartsWith(u.PasswordSalt));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.PasswordSalt.StartsWith(value) || value.StartsWith(u.PasswordSalt));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.PasswordSalt.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.EndsWith(u.PasswordSalt));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.PasswordSalt.EndsWith(value) || value.EndsWith(u.PasswordSalt));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithPasswordFormat(PasswordStoringFormat? value = null,
		                                    ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                    EnumOperator @operator = EnumOperator.Equal) {
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
				case EnumOperator.Equal:
					Entities = Entities.Where(u => u.PasswordFormat == value);
					return this;

				case EnumOperator.NotEqual:
					Entities = Entities.Where(u => u.PasswordFormat != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithLastLoginDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(u => u.LastLoginDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(u => u.LastLoginDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(u => u.LastLoginDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(u => u.LastLoginDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(u => u.LastLoginDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(u => u.LastLoginDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithLastLoginDateUtcBetween(DateTime? from = null,
		                                             ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             DateTime? to = null,
		                                             ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                             RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(u => u.LastLoginDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastLoginDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(u => u.LastLoginDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastLoginDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(u => u.LastLoginDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastLoginDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(u => u.LastLoginDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastLoginDateUtc == to);
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

		public UserQuery WithLastActivityDateUtc(DateTime? value = null,
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
					Entities = Entities.Where(u => u.LastActivityDateUtc == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(u => u.LastActivityDateUtc != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(u => u.LastActivityDateUtc >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(u => u.LastActivityDateUtc > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(u => u.LastActivityDateUtc <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(u => u.LastActivityDateUtc < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithLastActivityDateUtcBetween(DateTime? from = null,
		                                                ArgumentEvaluationMode fromMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                DateTime? to = null,
		                                                ArgumentEvaluationMode toMode = ArgumentEvaluationMode.IgnoreNeutral,
		                                                RangeOperator @operator = RangeOperator.Inside) {
			switch (@operator) {
				case RangeOperator.Inside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(u => u.LastActivityDateUtc >= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastActivityDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(u => u.LastActivityDateUtc <= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastActivityDateUtc == to);
							break;

						default:
							throw new NotSupportedEnumException(toMode);
					}
					break;

				case RangeOperator.Outside:
					switch (fromMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(from))
								Entities = Entities.Where(u => u.LastActivityDateUtc <= from);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastActivityDateUtc == from);
							break;

						default:
							throw new NotSupportedEnumException(fromMode);
					}

					switch (toMode) {
						case ArgumentEvaluationMode.IgnoreNeutral:
							if (!Neutrals.Is(to))
								Entities = Entities.Where(u => u.LastActivityDateUtc >= to);
							break;

						case ArgumentEvaluationMode.Explicit:
							Entities = Entities.Where(u => u.LastActivityDateUtc == to);
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

		public UserQuery WithLastIpAddress(string value = null,
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
							Entities = Entities.Where(u => u.LastIpAddress == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.LastIpAddress.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.Contains(u.LastIpAddress));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.LastIpAddress.Contains(value) || value.Contains(u.LastIpAddress));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.LastIpAddress.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.StartsWith(u.LastIpAddress));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.LastIpAddress.StartsWith(value) || value.StartsWith(u.LastIpAddress));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.LastIpAddress.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.EndsWith(u.LastIpAddress));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.LastIpAddress.EndsWith(value) || value.EndsWith(u.LastIpAddress));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithAdminComment(string value = null,
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
							Entities = Entities.Where(u => u.AdminComment == value);
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.Contains:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.AdminComment.Contains(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.Contains(u.AdminComment));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.AdminComment.Contains(value) || value.Contains(u.AdminComment));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.StartsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.AdminComment.StartsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.StartsWith(u.AdminComment));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.AdminComment.StartsWith(value) || value.StartsWith(u.AdminComment));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case StringOperator.EndsWith:
					switch (direction) {
						case StringDirection.SourceToExpected:
							Entities = Entities.Where(u => u.AdminComment.EndsWith(value));
							return this;

						case StringDirection.ExpectedToSource:
							Entities = Entities.Where(u => value.EndsWith(u.AdminComment));
							return this;

						case StringDirection.TwoWay:
							Entities = Entities.Where(u => u.AdminComment.EndsWith(value) || value.EndsWith(u.AdminComment));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithCurrentBlockReason(BlockReason value = null,
		                                        ArgumentEvaluationMode mode = ArgumentEvaluationMode.IgnoreNeutral,
		                                        EntityOperator @operator = EntityOperator.Equal) {
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
				case EntityOperator.Equal:
					Entities = Entities.Where(u => u.CurrentBlockReason == value);
					return this;

				case EntityOperator.NotEqual:
					Entities = Entities.Where(u => u.CurrentBlockReason != value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithCurrentBlockReasonId(long? value = null,
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
					Entities = Entities.Where(u => u.CurrentBlockReason.Id == value);
					return this;

				case IntegralOperator.NotEqual:
					Entities = Entities.Where(u => u.CurrentBlockReason.Id != value);
					return this;

				case IntegralOperator.GreaterThanOrEqual:
					Entities = Entities.Where(u => u.CurrentBlockReason.Id >= value);
					return this;

				case IntegralOperator.GreaterThan:
					Entities = Entities.Where(u => u.CurrentBlockReason.Id > value);
					return this;

				case IntegralOperator.LessThanOrEqual:
					Entities = Entities.Where(u => u.CurrentBlockReason.Id <= value);
					return this;

				case IntegralOperator.LessThan:
					Entities = Entities.Where(u => u.CurrentBlockReason.Id < value);
					return this;

				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithRole(Role value = null,
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
							Entities = Entities.Where(u => u.Roles.Any(r => r == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Roles.All(r => r == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Roles.Any(r => r != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Roles.All(r => r != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithRoleId(long? value = null,
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
							Entities = Entities.Where(u => u.Roles.Any(r => r.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Roles.All(r => r.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Roles.Any(r => r.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Roles.All(r => r.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithActivity(Activity value = null,
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
							Entities = Entities.Where(u => u.Activities.Any(a => a == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Activities.All(a => a == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Activities.Any(a => a != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Activities.All(a => a != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithActivityId(long? value = null,
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
							Entities = Entities.Where(u => u.Activities.Any(a => a.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Activities.All(a => a.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Activities.Any(a => a.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Activities.All(a => a.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithLog(Log value = null,
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
							Entities = Entities.Where(u => u.Logs.Any(l => l == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Logs.All(l => l == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Logs.Any(l => l != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Logs.All(l => l != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithLogId(long? value = null,
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
							Entities = Entities.Where(u => u.Logs.Any(l => l.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Logs.All(l => l.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Logs.Any(l => l.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Logs.All(l => l.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithToDo(ToDo value = null,
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
							Entities = Entities.Where(u => u.ToDos.Any(td => td == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.ToDos.All(td => td == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.ToDos.Any(td => td != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.ToDos.All(td => td != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithToDoId(long? value = null,
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
							Entities = Entities.Where(u => u.ToDos.Any(td => td.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.ToDos.All(td => td.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.ToDos.Any(td => td.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.ToDos.All(td => td.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithTicket(Ticket value = null,
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
							Entities = Entities.Where(u => u.Tickets.Any(t => t == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Tickets.All(t => t == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Tickets.Any(t => t != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Tickets.All(t => t != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithTicketId(long? value = null,
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
							Entities = Entities.Where(u => u.Tickets.Any(t => t.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Tickets.All(t => t.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Tickets.Any(t => t.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Tickets.All(t => t.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithResponse(TicketResponse value = null,
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
							Entities = Entities.Where(u => u.Responses.Any(tr => tr == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Responses.All(tr => tr == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Responses.Any(tr => tr != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Responses.All(tr => tr != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithResponseId(long? value = null,
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
							Entities = Entities.Where(u => u.Tickets.Any(tr => tr.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Tickets.All(tr => tr.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Tickets.Any(tr => tr.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Tickets.All(tr => tr.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithIncomingFriendRequest(FriendRequest value = null,
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
							Entities = Entities.Where(u => u.IncomingFriendRequests.Any(fr => fr == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.IncomingFriendRequests.All(fr => fr == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.IncomingFriendRequests.Any(fr => fr != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.IncomingFriendRequests.All(fr => fr != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithIncomingFriendRequestId(long? value = null,
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
							Entities = Entities.Where(u => u.IncomingFriendRequests.Any(fr => fr.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.IncomingFriendRequests.All(fr => fr.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.IncomingFriendRequests.Any(fr => fr.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.IncomingFriendRequests.All(fr => fr.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithOutgoingFriendRequest(FriendRequest value = null,
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
							Entities = Entities.Where(u => u.OutgoingFriendRequests.Any(fr => fr == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.OutgoingFriendRequests.All(fr => fr == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.OutgoingFriendRequests.Any(fr => fr != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.OutgoingFriendRequests.All(fr => fr != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithOutgoingFriendRequestId(long? value = null,
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
							Entities = Entities.Where(u => u.OutgoingFriendRequests.Any(fr => fr.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.OutgoingFriendRequests.All(fr => fr.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.OutgoingFriendRequests.Any(fr => fr.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.OutgoingFriendRequests.All(fr => fr.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithBlog(Blog value = null,
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
							Entities = Entities.Where(u => u.Blogs.Any(b => b == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Blogs.All(b => b == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Blogs.Any(b => b != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Blogs.All(b => b != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithBlogId(long? value = null,
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
							Entities = Entities.Where(u => u.Blogs.Any(b => b.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Blogs.All(b => b.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Blogs.Any(b => b.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Blogs.All(b => b.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithOrder(Order value = null,
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
							Entities = Entities.Where(u => u.Orders.Any(o => o == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Orders.All(o => o == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Orders.Any(o => o != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Orders.All(o => o != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithOrderId(long? value = null,
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
							Entities = Entities.Where(u => u.Orders.Any(o => o.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Orders.All(o => o.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Orders.Any(o => o.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Orders.All(o => o.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithLike(Like value = null,
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
							Entities = Entities.Where(u => u.Likes.Any(l => l == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Likes.All(l => l == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Likes.Any(l => l != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Likes.All(l => l != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithLikeId(long? value = null,
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
							Entities = Entities.Where(u => u.Likes.Any(l => l.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Likes.All(l => l.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Likes.Any(l => l.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Likes.All(l => l.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithShare(Share value = null,
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
							Entities = Entities.Where(u => u.Shares.Any(s => s == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Shares.All(s => s == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Shares.Any(s => s != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Shares.All(s => s != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithShareId(long? value = null,
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
							Entities = Entities.Where(u => u.Shares.Any(s => s.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Shares.All(s => s.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.Shares.Any(s => s.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.Shares.All(s => s.Id != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithVotingRecord(PollVotingRecord value = null,
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
							Entities = Entities.Where(u => u.VotingRecords.Any(pvr => pvr == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.VotingRecords.All(pvr => pvr == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.VotingRecords.Any(pvr => pvr != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.VotingRecords.All(pvr => pvr != value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}
				default:
					throw new NotSupportedEnumException(@operator);
			}
		}

		public UserQuery WithVotingRecordId(long? value = null,
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
							Entities = Entities.Where(u => u.VotingRecords.Any(pvr => pvr.Id == value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.VotingRecords.All(pvr => pvr.Id == value));
							return this;

						default:
							throw new NotSupportedEnumException(direction);
					}

				case CollectionOperator.NotEqual:
					switch (direction) {
						case CollectionDirection.Any:
							Entities = Entities.Where(u => u.VotingRecords.Any(pvr => pvr.Id != value));
							return this;

						case CollectionDirection.All:
							Entities = Entities.Where(u => u.VotingRecords.All(pvr => pvr.Id != value));
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