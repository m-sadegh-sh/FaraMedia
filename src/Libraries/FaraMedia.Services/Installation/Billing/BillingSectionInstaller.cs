namespace FaraMedia.Services.Installation.Billing {
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class BillingSectionInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(BillingSectionConstants.Metadata.Title, "بخش مالی");
                NewResource(BillingSectionConstants.Metadata.Description, ResourceTemplates.SectionDescription("تراکنش ها"));

                NewResource(BillingSectionConstants.OrderStatusesController.List.Metadata.Title, "سفارشات");
                NewResource(BillingSectionConstants.OrderStatusesController.List.Metadata.Description, ResourceTemplates.ListDescription("سفارشات", "سفارش"));
                NewResource(BillingSectionConstants.OrderStatusesController.New.Metadata.Title, ResourceTemplates.NewTitle("سفارش"));
                NewResource(BillingSectionConstants.OrderStatusesController.New.Metadata.Description, ResourceTemplates.NewDescription("سفارش"));
                NewResource(BillingSectionConstants.OrderStatusesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("سفارش"));
                NewResource(BillingSectionConstants.OrderStatusesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("سفارش"));

                NewResource(BillingSectionConstants.OrdersController.List.Metadata.Title, "سفارشات");
                NewResource(BillingSectionConstants.OrdersController.List.Metadata.Description, ResourceTemplates.ListDescription("سفارشات", "سفارش"));
                NewResource(BillingSectionConstants.OrdersController.Edit.Metadata.Title, ResourceTemplates.EditTitle("سفارش"));
                NewResource(BillingSectionConstants.OrdersController.Edit.Metadata.Description, ResourceTemplates.EditDescription("سفارش"));

                NewResource(BillingSectionConstants.OrderNotesController.List.Metadata.Title, "سفارشات");
                NewResource(BillingSectionConstants.OrderNotesController.List.Metadata.Description, ResourceTemplates.ListDescription("سفارشات", "سفارش"));
                NewResource(BillingSectionConstants.OrderNotesController.New.Metadata.Title, ResourceTemplates.NewTitle("سفارش"));
                NewResource(BillingSectionConstants.OrderNotesController.New.Metadata.Description, ResourceTemplates.NewDescription("سفارش"));
                NewResource(BillingSectionConstants.OrderNotesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("سفارش"));
                NewResource(BillingSectionConstants.OrderNotesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("سفارش"));

                NewResource(BillingSectionConstants.OrderLinesController.List.Metadata.Title, "سفارشات");
                NewResource(BillingSectionConstants.OrderLinesController.List.Metadata.Description, ResourceTemplates.ListDescription("سفارشات", "سفارش"));
                NewResource(BillingSectionConstants.OrderLinesController.Edit.Metadata.Title, ResourceTemplates.EditTitle("سفارش"));
                NewResource(BillingSectionConstants.OrderLinesController.Edit.Metadata.Description, ResourceTemplates.EditDescription("سفارش"));

                NewResource(BillingSectionConstants.TransactionRequestsController.List.Metadata.Title, "سفارشات");
                NewResource(BillingSectionConstants.TransactionRequestsController.List.Metadata.Description, ResourceTemplates.ListDescription("سفارشات", "سفارش"));
                NewResource(BillingSectionConstants.TransactionRequestsController.New.Metadata.Title, ResourceTemplates.NewTitle("سفارش"));
                NewResource(BillingSectionConstants.TransactionRequestsController.New.Metadata.Description, ResourceTemplates.NewDescription("سفارش"));
                NewResource(BillingSectionConstants.TransactionRequestsController.Edit.Metadata.Title, ResourceTemplates.EditTitle("سفارش"));
                NewResource(BillingSectionConstants.TransactionRequestsController.Edit.Metadata.Description, ResourceTemplates.EditDescription("سفارش"));

                NewResource(BillingSectionConstants.TransactionResponsesController.List.Metadata.Title, "تراکنش ها");
                NewResource(BillingSectionConstants.TransactionResponsesController.List.Metadata.Description, ResourceTemplates.ListDescription("تراکنش ها", "تراکنش"));

                transaction.Commit();
            }
        }
    }
}