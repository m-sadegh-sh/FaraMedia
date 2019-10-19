namespace FaraMedia.Data.Schemas {
	using System;
	using System.Linq.Expressions;

	public class ConstantKeyHelpers {
		protected const string KeySeparator = ".";

		public string Label<TContainer>() {
			throw new NotImplementedException();
		}

		public string Key<TContainer, TProperty>(Expression<Func<TContainer, TProperty>> property) {
			return Key<TContainer>(property.Body.ToString());
		}

		public string Key<TContainer>(string property) {
			throw new NotImplementedException();
		}

		public string Enum<TContainer, TEnum>(TEnum member) where TContainer : class where TEnum : struct {
			if (!typeof (TEnum).IsEnum)
				throw new InvalidOperationException("Parameter enumMember isn't an enum");

			throw new NotImplementedException();
		}

		public string SectionName<TContainer>() {
			throw new NotImplementedException();
		}

		public string ControllerName<TContainer>() {
			throw new NotImplementedException();
		}

		public string ActionName<TContainer>() {
			throw new NotImplementedException();
		}
	}
}