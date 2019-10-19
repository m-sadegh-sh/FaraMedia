namespace FaraMedia.FrontEnd.Administration.Controllers {
    using System;
    using System.Linq;

    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Data.Schemas.Billing;
    using FaraMedia.Data.Schemas.Layout.Sections;
    using FaraMedia.FrontEnd.Administration.Controllers.Abstracts;
    using FaraMedia.FrontEnd.Administration.Models.Billing;
    using FaraMedia.Services.Billing;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Security;
    using FaraMedia.Web.Framework.Mvc.Attributes;

    [SectionName(BillingSectionConstants.SectionName)]
    public class TransactionDebugsController : AbstractCrudControllerBase<TransactionDebug, TransactionDebugModel> {
        private readonly ITransactionDebugService _transactionDebugService;

        public TransactionDebugsController(ITransactionDebugService transactionDebugService) {
            _transactionDebugService = transactionDebugService;
        }

        protected override Func<PermissionRecord> UserizedPermissionRecord {
            get { return () => StandardPermissionProvider.ManageTransactionDebugs; }
        }

        protected override Func<TransactionDebug> LoadEntityById(long id) {
            return () => _transactionDebugService.LoadTransactionDebugById(id);
        }

        protected override Func<IQueryable<TransactionDebug>> GetAllEntities {
            get { return () => _transactionDebugService.GetAllTransactionDebugs(); }
        }

        protected override Func<ServiceOperationResult> InsertEntityAndReturnOperationResult(TransactionDebug transactionDebug) {
            return () => _transactionDebugService.InsertTransactionDebug(transactionDebug);
        }

        protected override Func<ServiceOperationResult> UpdateEntityAndReturnOperationResult(TransactionDebug transactionDebug) {
            return () => _transactionDebugService.UpdateTransactionDebug(transactionDebug);
        }

        protected override Func<ServiceOperationResult> DeleteEntityAndReturnOperationResult(TransactionDebug transactionDebug, bool onlyChangeFlag = true) {
            return () => _transactionDebugService.DeleteTransactionDebug(transactionDebug, onlyChangeFlag);
        }
    }
}