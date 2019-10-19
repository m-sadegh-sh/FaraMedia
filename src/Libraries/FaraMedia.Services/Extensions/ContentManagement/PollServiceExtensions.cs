namespace FaraMedia.Services.Extensions.ContentManagement {
	using FaraMedia.Core;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Services.Querying.ContentManagement;

	public static class PollServiceExtensions {
		public static Poll GetByPlaceholderKey(this IDbService<Poll, PollQuery> service,
		                                       string placeholderKey) {
			if (Neutrals.Is(placeholderKey))
				return null;

			var poll = service.Get(pq => pq.WithPlaceholderKey(placeholderKey));

			return poll;
		}
	}
}