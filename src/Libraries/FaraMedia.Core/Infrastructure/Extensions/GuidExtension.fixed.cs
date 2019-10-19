namespace FaraMedia.Core.Infrastructure.Extensions {
	using System;

	public static class GuidExtension {
		public static bool IsEmpty(this Guid value) {
			return value.Equals(Guid.Empty);
		}

		public static string Shrink(this Guid value) {
			var base64 = Convert.ToBase64String(value.ToByteArray());

			var encoded = base64.Replace("/",
			                             "_").
			                     Replace("+",
			                             "-");

			return encoded.Substring(0,
			                         22);
		}
	}
}