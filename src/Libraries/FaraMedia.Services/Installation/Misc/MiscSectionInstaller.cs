namespace FaraMedia.Services.Installation.Misc {
    using FaraMedia.Data.Schemas.Misc;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class MiscSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(MiscSectionConstants.Metadata.Title, "بخش تیکتینک");
                NewResource(MiscSectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("تیکت ها"));

                NewResource(MiscSectionConstants.RedirectorsController.List.Metadata.Title, "آدرس ها (تغییر مسیر)");
                NewResource(MiscSectionConstants.RedirectorsController.List.Metadata.Description, ResourceTemplates.ListDescription("آدرس ها (تغییر مسیر)", "آدرس"));
                NewResource(MiscSectionConstants.RedirectorsController.New.Metadata.Title, ResourceTemplates.NewTitle("آدرس"));
                NewResource(MiscSectionConstants.RedirectorsController.New.Metadata.Description, ResourceTemplates.NewDescription("آدرس"));
                NewResource(MiscSectionConstants.RedirectorsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("آدرس"));
                NewResource(MiscSectionConstants.RedirectorsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("آدرس"));

                NewResource(MiscSectionConstants.TicketsController.List.Metadata.Title, "تیکت ها");
                NewResource(MiscSectionConstants.TicketsController.List.Metadata.Description, ResourceTemplates.ListDescription("تیکت ها", "تیکت ها"));

                NewResource(MiscSectionConstants.TicketResponsesController.List.Metadata.Title, "تیکت ها");
                NewResource(MiscSectionConstants.TicketResponsesController.List.Metadata.Description, ResourceTemplates.ListDescription("تیکت ها", "تیکت ها"));
                NewResource(MiscSectionConstants.TicketResponsesController.New.Metadata.Title, ResourceTemplates.NewTitle("تیکت ها"));
                NewResource(MiscSectionConstants.TicketResponsesController.New.Metadata.Description, ResourceTemplates.NewDescription("تیکت ها"));
                NewResource(MiscSectionConstants.TicketResponsesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("تیکت ها"));
                NewResource(MiscSectionConstants.TicketResponsesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("تیکت ها"));

                NewResource(MiscSectionConstants.ToDosController.List.Metadata.Title, "برنامه ها");
                NewResource(MiscSectionConstants.ToDosController.List.Metadata.Description, ResourceTemplates.ListDescription("برنامه ها", "برنامه"));
                NewResource(MiscSectionConstants.ToDosController.New.Metadata.Title, ResourceTemplates.NewTitle("برنامه"));
                NewResource(MiscSectionConstants.ToDosController.New.Metadata.Description, ResourceTemplates.NewDescription("برنامه"));
                NewResource(MiscSectionConstants.ToDosController.Edit.Metadata.Title, ResourceTemplates.EditTitle("برنامه"));
                NewResource(MiscSectionConstants.ToDosController.Edit.Metadata.Description, ResourceTemplates.EditDescription("برنامه"));

                transaction.Commit();
            }
        }
    }
}