namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public class QueuedEmailInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(QueuedEmailConstants.Fields.From.Label, "آدرس ارسال کننده");
                NewResource(QueuedEmailConstants.Fields.FromName.Label, "نام ارسال کننده");
                NewResource(QueuedEmailConstants.Fields.To.Label, "آدرس دریافت کننده");
                NewResource(QueuedEmailConstants.Fields.ToName.Label, "نام دریافت کننده");
                NewResource(QueuedEmailConstants.Fields.Cc.Label, "ارسال به (سی سی)");
                NewResource(QueuedEmailConstants.Fields.Bcc.Label, "ارسال به (بی سی سی)");
                NewResource(QueuedEmailConstants.Fields.Subject.Label, "عنوان");
                NewResource(QueuedEmailConstants.Fields.Body.Label, "متن");

                NewResource(QueuedEmailConstants.Fields.SendPriority.Label, "اولویت");
                NewResource(QueuedEmailConstants.Fields.SendPriority.Low, "پایین");
                NewResource(QueuedEmailConstants.Fields.SendPriority.Normal, "متوسط");
                NewResource(QueuedEmailConstants.Fields.SendPriority.High, "بالا");
                NewResource(QueuedEmailConstants.Fields.SentDateUtc.Label, "تاریخ ارسال");
                NewResource(QueuedEmailConstants.Fields.SendingTries.Label, "تعداد تلاش");
                NewResource(QueuedEmailConstants.Fields.SentDateUtc.Label, "تعداد تلاش");

                NewResource(QueuedEmailConstants.Fields.EmailAccount.Label, "حساب ایمیل");

                transaction.Commit();
            }
        }
    }
}