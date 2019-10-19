namespace FaraMedia.Services.Installation.Systematic {
    using System;

    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;
    using FaraMedia.Services.Tasks;

    using NHibernate;

    public class ScheduleTaskInstaller : EntityInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(ScheduleTaskConstants.Fields.DisplayName.Label, "نام");
                NewResource(ScheduleTaskConstants.Fields.TypeName.Label, "نوع");
                NewResource(ScheduleTaskConstants.Fields.Description.Label, "نوع");

                NewResource(ScheduleTaskConstants.Fields.ExecutionPriority.Label, "ایست هنگام خطا");
                NewResource(ScheduleTaskConstants.Fields.IsActive.Label, "ایست هنگام خطا");
                NewResource(ScheduleTaskConstants.Fields.StopOnError.Label, "ایست هنگام خطا");
                NewResource(ScheduleTaskConstants.Fields.MaximumRunningSeconds.Label, "زمان اجرا (ثانیه)");

                transaction.Commit();
            }
        }

        public override void InstallEntities(IStatelessSession session) {
            using (var transaction = session.BeginTransaction()) {
                session.Insert(new ScheduleTask {
                    StopOnError = false,
                    MaximumRunningSeconds = (int) TimeSpan.FromSeconds(60).TotalSeconds,
                    DisplayName = "ارسال ایمیل های موجود در صف",
                    TypeName = typeof (QueuedMessagesSendTask).FullName
                });

                session.Insert(new ScheduleTask {
                    StopOnError = false,
                    MaximumRunningSeconds = (int) TimeSpan.FromMinutes(10).TotalSeconds,
                    DisplayName = "حذف حساب های کاربری مهمان",
                    TypeName = typeof (DeleteGuestUsersTask).FullName
                });

                session.Insert(new ScheduleTask {
                    StopOnError = false,
                    MaximumRunningSeconds = (int) TimeSpan.FromMinutes(10).TotalSeconds,
                    DisplayName = "پاک کردن کش",
                    TypeName = typeof (ClearCacheTask).FullName
                });

                session.Insert(new ScheduleTask {
                    StopOnError = false,
                    MaximumRunningSeconds = (int) TimeSpan.FromDays(365).TotalSeconds,
                    DisplayName = "حذف سوابق",
                    TypeName = typeof (ClearLogTask).FullName
                });

                session.Insert(new ScheduleTask {
                    StopOnError = false,
                    MaximumRunningSeconds = (int) TimeSpan.FromDays(365).TotalSeconds,
                    DisplayName = "حذف سوابق فعالیت",
                    TypeName = typeof (ClearActivityTask).FullName
                });

                transaction.Commit();
            }
        }
    }
}