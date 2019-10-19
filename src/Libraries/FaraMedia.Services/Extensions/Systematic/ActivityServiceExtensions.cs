namespace FaraMedia.Services.Extensions.Systematic {
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Services.Querying.Systematic;

    public static class ActivityServiceExtensions {
        public static void Clear(this IDbService<Activity, ActivityQuery> service) {
            var activities = service.GetAll();

            foreach (var activity in activities)
                service.Delete(activity);
        }
    }
}