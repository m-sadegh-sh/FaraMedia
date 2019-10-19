namespace FaraMedia.Services.Extensions.Systematic {
    using System;
    using System.Threading;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Querying.Systematic;

    public static class LogServiceExtensions {
        public static bool IsEnabled(this IDbService<Log, LogQuery> service, LogLevel level) {
            switch (level) {
                case LogLevel.Debug:
                    return false;
                default:
                    return true;
            }
        }

        public static void Debug(this IDbService<Log, LogQuery> service, string message, Exception exception = null, User user = null) {
            BuildLog(service, LogLevel.Debug, message, exception, user);
        }

        public static void Information(this IDbService<Log, LogQuery> service, string message, Exception exception = null, User user = null) {
            BuildLog(service, LogLevel.Information, message, exception, user);
        }

        public static void Warning(this IDbService<Log, LogQuery> service, string message, Exception exception = null, User user = null) {
            BuildLog(service, LogLevel.Warning, message, exception, user);
        }

        public static void Error(this IDbService<Log, LogQuery> service, string message, Exception exception = null, User user = null) {
            BuildLog(service, LogLevel.Error, message, exception, user);
        }

        public static void Fatal(this IDbService<Log, LogQuery> service, string message, Exception exception = null, User user = null) {
            BuildLog(service, LogLevel.Fatal, message, exception, user);
        }

        private static void BuildLog(IDbService<Log, LogQuery> service, LogLevel level, string message, Exception exception = null, User user = null) {
            if (exception != null && exception is ThreadAbortException)
                return;

            if (!service.IsEnabled(level))
                return;

            var fullMessage = exception == null ? string.Empty : exception.ToString();

            service.Save(level, message, fullMessage, user);
        }

        public static ServiceOperationResultWithValue<Log> Save(this IDbService<Log, LogQuery> service, LogLevel level, string shortMessage, string fullMessage = "", User invoker = null) {
            var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<Log>>();

            var webHelper = EngineContext.Current.Resolve<IWebHelper>();

            var log = new Log {
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                RequestedUrl = webHelper.GetUrl(true, true),
                ReferrerUrl = webHelper.GetReferrer(),
                LogDateUtc = DateTime.UtcNow,
                Level = level,
                Invoker = invoker,
                InvokerIp = webHelper.GetIpAddress()
            };

            result.CopyFrom(service.Save(log));

            return result.With(log);
        }

        public static void Clear(this IDbService<Log, LogQuery> service) {
            var logs = service.GetAll();

            foreach (var log in logs)
                service.Delete(log);
        }
    }
}