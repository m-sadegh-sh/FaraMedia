namespace FaraMedia.Services.Installation.Abstraction {
    public static class ResourceTemplates {
        public static string SectionDescription(params object[] args) {
            return string.Format("برای مدیریت {0} از این قسمت استفاده کنید.", args);
        }

        public static string ListDescription(params object[] args) {
            return string.Format("در زیر لیست تمامی {0} ثبت شده در سیستم آمده است. شما می توانید با کلیک بر روی گزینه جدید در بالا اقدام به ثبت {1} جدید، با کلیک بر روی گزینه ویرایش اقدام به ویرایش و با کلیک بر روی حذف اقدام به حذف {1} مورد نظر کنید.", args);
        }

        public static string NewTitle(params object[] args) {
            return string.Format("ثبت {0} جدید", args);
        }

        public static string NewDescription(params object[] args) {
            return string.Format("در این صفحه فرمی برای وارد نمودن اطلاعات مورد نیاز {0} آورده شده است. فیلد ها را پر کرده و بر روی ذخیره/ذخیره و ادامه کلیک کنید. در صورت تمایل می توانید بر روی گزینه ی برگشت به لیست کلیک کرده و از ثبت {0} جدید انصراف دهید.", args);
        }

        public static string EditTitle(params object[] args) {
            return string.Format("ویرایش {0}: {{0}}", args);
        }

        public static string EditDescription(params object[] args) {
            return string.Format("در این صفحه فرمی برای بروز رسانی اطلاعات مورد نیاز {0} مورد نظر آورده شده است. فیلد ها را ویرایش و بر روی بروز رسانی/بروز رسانی و ادامه کلیک کنید. در صورت تمایل می توانید بر روی گزینه ی برگشت به لیست کلیک کرده و از بروز رسانی {0} مورد انصراف دهید.", args);
        }

        public static string SaveTitle(params object[] args) {
            return string.Format("تنظیمات {0}", args);
        }

        public static string SaveDescription(params object[] args) {
            return string.Format("در این صفحه فرمی برای بروز رسانی اطلاعات مورد نیاز تنظیمات {0} آورده شده است. فیلد ها را ویرایش و بر روی ذخیره/ذخیره و ادامه کلیک کنید. در صورت تمایل می توانید بر روی گزینه ی برگشت به خانه کلیک کرده و از بروز رسانی تنظیمات {0} انصراف دهید.", args);
        }
    }
}