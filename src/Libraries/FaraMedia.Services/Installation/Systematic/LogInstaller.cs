namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class LogInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(LogConstants.Fields.ShortMessage.Label, "پیام (خلاصه)");
                NewResource(LogConstants.Fields.FullMessage.Label, "پیام (کامل)");
                NewResource(LogConstants.Fields.RequestedUrl.Label, "آدرس صفحه");
                NewResource(LogConstants.Fields.ReferrerUrl.Label, "آدرس صفحه (ارسال کننده)");

                NewResource(LogConstants.Fields.Level.Label, "نوع");
                NewResource(LogConstants.Fields.Level.Debug, "اشکال زدایی");
                NewResource(LogConstants.Fields.Level.Information, "اطلاعات");
                NewResource(LogConstants.Fields.Level.Warning, "هشدار");
                NewResource(LogConstants.Fields.Level.Error, "خطا");
                NewResource(LogConstants.Fields.Level.Fatal, "خطا (بحرانی)");
                NewResource(LogConstants.Fields.LogDateUtc.Label, "آدرس صفحه (ارسال کننده)");

                NewResource(LogConstants.Fields.Invoker.Label, "توسط");
                NewResource(LogConstants.Fields.InvokerIp.Label, "توسط");

                transaction.Commit();
            }
        }
    }
}