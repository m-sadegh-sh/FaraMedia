namespace FaraMedia.Services.Installation.Systematic {
    using FaraMedia.Data.Schemas.Systematic;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class SystematicSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(SystematicSectionConstants.Metadata.Title, "بخش محلی سازی");
                NewResource(SystematicSectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("زبان ها و ریسورس ها"));
                
                NewResource(SystematicSectionConstants.ResourceKeysController.List.Metadata.Title, "ریسورس ها");
                NewResource(SystematicSectionConstants.ResourceKeysController.List.Metadata.Description, ResourceTemplates.ListDescription("ریسورس ها", "ریسورس"));
                NewResource(SystematicSectionConstants.ResourceKeysController.New.Metadata.Title, ResourceTemplates.NewTitle("ریسورس"));
                NewResource(SystematicSectionConstants.ResourceKeysController.New.Metadata.Description, ResourceTemplates.NewDescription("ریسورس"));
                NewResource(SystematicSectionConstants.ResourceKeysController.Edit.Metadata.Title, ResourceTemplates.EditTitle("ریسورس"));
                NewResource(SystematicSectionConstants.ResourceKeysController.Edit.Metadata.Description, ResourceTemplates.EditDescription("ریسورس"));

                NewResource(SystematicSectionConstants.ResourceValuesController.List.Metadata.Title, "ریسورس ها");
                NewResource(SystematicSectionConstants.ResourceValuesController.List.Metadata.Description, ResourceTemplates.ListDescription("ریسورس ها", "ریسورس"));
                NewResource(SystematicSectionConstants.ResourceValuesController.New.Metadata.Title, ResourceTemplates.NewTitle("ریسورس"));
                NewResource(SystematicSectionConstants.ResourceValuesController.New.Metadata.Description, ResourceTemplates.NewDescription("ریسورس"));
                NewResource(SystematicSectionConstants.ResourceValuesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("ریسورس"));
                NewResource(SystematicSectionConstants.ResourceValuesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("ریسورس"));

                NewResource(SystematicSectionConstants.ActivityTypesController.List.Metadata.Title, "انواع فعالیت ها");
                NewResource(SystematicSectionConstants.ActivityTypesController.List.Metadata.Description, ResourceTemplates.ListDescription("انواع فعالیت ها", "انواع فعالیت"));
                NewResource(SystematicSectionConstants.ActivityTypesController.New.Metadata.Title, ResourceTemplates.NewTitle("انواع فعالیت"));
                NewResource(SystematicSectionConstants.ActivityTypesController.New.Metadata.Description, ResourceTemplates.NewDescription("انواع فعالیت"));
                NewResource(SystematicSectionConstants.ActivityTypesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("انواع فعالیت"));
                NewResource(SystematicSectionConstants.ActivityTypesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("انواع فعالیت"));

                NewResource(SystematicSectionConstants.ActivitiesController.List.Metadata.Title, "فعالیت ها");
                NewResource(SystematicSectionConstants.ActivitiesController.List.Metadata.Description, ResourceTemplates.ListDescription("فعالیت ها", "فعالیت"));

                NewResource(SystematicSectionConstants.LogsController.List.Metadata.Title, "لاگ ها");
                NewResource(SystematicSectionConstants.LogsController.List.Metadata.Description, ResourceTemplates.ListDescription("لاگ ها", "لاگ"));

                NewResource(SystematicSectionConstants.EmailAccountsController.List.Metadata.Title, "حساب های ایمیل");
                NewResource(SystematicSectionConstants.EmailAccountsController.List.Metadata.Description, ResourceTemplates.ListDescription("حساب های ایمیل", "حساب ایمیل"));
                NewResource(SystematicSectionConstants.EmailAccountsController.New.Metadata.Title, ResourceTemplates.NewTitle("حساب ایمیل"));
                NewResource(SystematicSectionConstants.EmailAccountsController.New.Metadata.Description, ResourceTemplates.NewDescription("حساب ایمیل"));
                NewResource(SystematicSectionConstants.EmailAccountsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("حساب ایمیل"));
                NewResource(SystematicSectionConstants.EmailAccountsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("حساب ایمیل"));

                NewResource(SystematicSectionConstants.MessageTemplatesController.List.Metadata.Title, "قالب های پیام");
                NewResource(SystematicSectionConstants.MessageTemplatesController.List.Metadata.Description, ResourceTemplates.ListDescription("قالب های پیام", "قالب پیام"));
                NewResource(SystematicSectionConstants.MessageTemplatesController.New.Metadata.Title, ResourceTemplates.NewTitle("قالب پیام"));
                NewResource(SystematicSectionConstants.MessageTemplatesController.New.Metadata.Description, ResourceTemplates.NewDescription("قالب پیام"));
                NewResource(SystematicSectionConstants.MessageTemplatesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("قالب پیام"));
                NewResource(SystematicSectionConstants.MessageTemplatesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("قالب پیام"));

                NewResource(SystematicSectionConstants.NewsletterSubscriptionsController.List.Metadata.Title, "اشتراک های خبرنامه");
                NewResource(SystematicSectionConstants.NewsletterSubscriptionsController.List.Metadata.Description, ResourceTemplates.ListDescription("اشتراک های خبرنامه", "اشتراک خبرنامه"));

                NewResource(SystematicSectionConstants.QueuedEmailsController.List.Metadata.Title, "ایمیل های در صف");
                NewResource(SystematicSectionConstants.QueuedEmailsController.List.Metadata.Description, ResourceTemplates.ListDescription("ایمیل های در صف", "ایمیل در صف"));
                
                NewResource(SystematicSectionConstants.ScheduleTasksController.List.Metadata.Title, "وظایف زمانبندی شده");
                NewResource(SystematicSectionConstants.ScheduleTasksController.List.Metadata.Description, ResourceTemplates.ListDescription("وظایف زمانبندی شده", "وظیفه زمانبندی شده"));
                NewResource(SystematicSectionConstants.ScheduleTasksController.New.Metadata.Title, ResourceTemplates.NewTitle("وظیفه زمانبندی شده"));
                NewResource(SystematicSectionConstants.ScheduleTasksController.New.Metadata.Description, ResourceTemplates.NewDescription("وظیفه زمانبندی شده"));
                NewResource(SystematicSectionConstants.ScheduleTasksController.Edit.Metadata.Title, ResourceTemplates.EditTitle("وظیفه زمانبندی شده"));
                NewResource(SystematicSectionConstants.ScheduleTasksController.Edit.Metadata.Description, ResourceTemplates.EditDescription("وظیفه زمانبندی شده"));

                transaction.Commit();
            }
        }
    }
}