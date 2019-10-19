namespace FaraMedia.Data.NHibernating.CustomTypes {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text;

	using NHibernate;
	using NHibernate.SqlTypes;
	using NHibernate.UserTypes;

	using TB.ComponentModel;

	public sealed class CsvFormattedUserType<TType> : IUserType {
		private const char STRING_SEPARATOR = ',';

		bool IUserType.Equals(object x,
		                      object y) {
			if (x == null || y == null)
				return false;

			var left = (IList<TType>) x;
			var right = (IList<TType>) y;

			if (left.Count != right.Count)
				return false;

			var retvalue = !left.Except(right).
			                     Any();

			return retvalue;
		}

		public object Assemble(object cached,
		                       object owner) {
			return cached;
		}

		public object DeepCopy(object value) {
			return ((IList<TType>) value).ToList();
		}

		public object Disassemble(object value) {
			return value;
		}

		public int GetHashCode(object x) {
			return x.GetHashCode();
		}

		public bool IsMutable {
			get { return true; }
		}

		public object NullSafeGet(IDataReader rs,
		                          string[] names,
		                          object owner) {
			var index = rs.GetOrdinal(names[0]);
			var value = (string) rs[index];
			var result = new List<TType>();

			if (rs.IsDBNull(index) || string.IsNullOrEmpty(value))
				return result;

			var items = value.Split(STRING_SEPARATOR);

			foreach (var item in items)
				result.Add(item.ConvertTo<TType>());

			return result;
		}

		public void NullSafeSet(IDbCommand cmd,
		                        object value,
		                        int index) {
			if (value == null || value == DBNull.Value) {
				NHibernateUtil.String.NullSafeSet(cmd,
				                                  null,
				                                  index);
			}

			var list = (IEnumerable<TType>) value;
			var builder = new StringBuilder();

			foreach (var item in list) {
				builder.Append(item);
				builder.Append(STRING_SEPARATOR);
			}

			if (builder.Length > 0)
				builder.Length--;

			NHibernateUtil.String.Set(cmd,
			                          builder.ToString(),
			                          index);
		}

		public object Replace(object original,
		                      object target,
		                      object owner) {
			return original;
		}

		public Type ReturnedType {
			get { return typeof (IList<String>); }
		}

		public SqlType[] SqlTypes {
			get { return new[] {NHibernateUtil.String.SqlType}; }
		}
	}
}