namespace FaraMedia.Web.Framework.Mvc.Attributes {
    using System.Web.Mvc;

    using FaraMedia.Core.Data;

    public class UnitOfWorkFilter : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext) {
            var unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();

            unitOfWork.BeginTransaction();
        }

        public override void OnResultExecuted(ResultExecutedContext resultExecutedContext) {
            var unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();

            unitOfWork.EndTransaction();
        }
    }
}