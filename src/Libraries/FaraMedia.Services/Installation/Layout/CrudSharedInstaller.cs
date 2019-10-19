namespace FaraMedia.Services.Installation.Layout {
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class CrudSharedInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(CrudSharedConstants.Commands.Back, "برگشت");
                NewResource(CrudSharedConstants.Commands.BackTo, "برگشت به {0}");
                NewResource(CrudSharedConstants.Commands.Details, "جزئیات");
                NewResource(CrudSharedConstants.Commands.New, "جدید");
                NewResource(CrudSharedConstants.Commands.Create, "ثبت");
                NewResource(CrudSharedConstants.Commands.CreateContinue, "ثبت و ادامه");
                NewResource(CrudSharedConstants.Commands.Edit, "ویرایش");
                NewResource(CrudSharedConstants.Commands.Update, "بروز رسانی");
                NewResource(CrudSharedConstants.Commands.Publish, "انتشار");
                NewResource(CrudSharedConstants.Commands.PublishAll, "انتشار همه");
                NewResource(CrudSharedConstants.Commands.Unpublish, "عدم انتشار");
                NewResource(CrudSharedConstants.Commands.UnpublishAll, "عدم انتشار همه");
                NewResource(CrudSharedConstants.Commands.UpdateContinue, "بروز رسانی و ادامه");
                NewResource(CrudSharedConstants.Commands.Delete, "حذف");
                NewResource(CrudSharedConstants.Commands.TemporarilyDelete, "حذف موقت");
                NewResource(CrudSharedConstants.Commands.TemporarilyDeleteAll, "حذف موقت همه");
                NewResource(CrudSharedConstants.Commands.UnDeleteAll, "عدم حذف موقت همه");
                NewResource(CrudSharedConstants.Commands.PermanentlyDelete, "حذف دائم");
                NewResource(CrudSharedConstants.Commands.PermanentlyDeleteAll, "حذف دائم همه");
                NewResource(CrudSharedConstants.Commands.Save, "ذخیره");
                NewResource(CrudSharedConstants.Commands.SaveContinue, "ذخیره و ادامه");
                NewResource(CrudSharedConstants.Commands.YesSure, "بله، مطمئنم!");
                NewResource(CrudSharedConstants.Commands.NoCancel, "نه، انصراف می دهم!");

                NewResource(CrudSharedConstants.Messages.InvalidParameter, "بدلیل نامعتبر بودن یک یا چند پارامتر دریافتی درخواست مورد نظر رد شد.");
                NewResource(CrudSharedConstants.Messages.Confirmation, "آیا مطمئن هستید...");
                NewResource(CrudSharedConstants.Messages.AreYouSureToDelete, "کاربر گرامی، برای حذف موقت رکورد مورد نظر گزینه حذف موقت و برای حذف دائمی گرینه حذف دائم را انتخاب کنید.");

                transaction.Commit();
            }
        }
    }
}