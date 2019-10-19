namespace FaraMedia.Web.Framework.Mvc.Controllers {
    using System.Web.Mvc;

    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public abstract class FullCrudControllerBase<TEditableModel> : CrudControllerBase where TEditableModel : EditableEntityModelBase {
        public abstract ActionResult New();

        public abstract ActionResult New(TEditableModel editableModel, bool continueEditing);

        public abstract ActionResult Edit(long id);

        public abstract ActionResult Edit(TEditableModel editableModel, bool continueEditing);
    }
}