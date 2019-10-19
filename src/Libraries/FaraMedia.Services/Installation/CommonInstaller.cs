namespace FaraMedia.Services.Installation {
    using FaraMedia.Data.Schemas;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class CommonInstaller : ResourceInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(CommonConstants.Messages.NullEntity, "رکوردی یافت نشد.");
                NewResource(CommonConstants.Messages.UnknownEntity, "رکوردی با شناسه مورد نظر یافت نشد.");
                NewResource(CommonConstants.Messages.NullSettings, "تنظیمات یافت نشد.");
                NewResource(CommonConstants.Messages.Inserted, "اطلاعات رکورد مورد نظر با موفقیت ثبت شد.");
                NewResource(CommonConstants.Messages.NotInserted, "امکان ثبت اطلاعات رکورد مورد نظر وجود ندارد. پس از بررسی مجدد فرم، لطفا دوباره تلاش کنید.");
                NewResource(CommonConstants.Messages.Updated, "اطلاعات رکورد(های) مورد نظر با موفقیت بروز شد.");
                NewResource(CommonConstants.Messages.NotUpdated, "امکان بروز رسانی اطلاعات رکورد مورد نظر وجود ندارد. پس از بررسی مجدد فرم، لطفا دوباره تلاش کنید.");
                NewResource(CommonConstants.Messages.Deleted, "رکورد(های) مورد نظر با موفقیت حذف شد.");
                NewResource(CommonConstants.Messages.NotDeleted, "امکان حذف اطلاعات رکورد مورد نظر وجود ندارد. پس از بررسی مجدد فرم، لطفا دوباره تلاش کنید.");
                NewResource(CommonConstants.Messages.DeleteConfirmation, "آیا واقعا مایل به حذف رکورد مورد نظر می باشید؟");
                NewResource(CommonConstants.Messages.Saved, "تنظیمات مورد نظر با موفقیت ذخیره شد.");
                NewResource(CommonConstants.Messages.NotSaved, "امکان ذخیره تنظیمات مورد نظر وجود ندارد. پس از بررسی مجدد فرم، لطفا دوباره تلاش کنید.");
                NewResource(CommonConstants.Messages.Empty, "رکوردی برای نمایش یافت نشد.");
                NewResource(CommonConstants.Messages.ActionFailed, "امکان انجام درخواست مورد نظر وجود ندارد.");
                NewResource(CommonConstants.Messages.ActionSucceded, "درخواست مورد نظر با موفقیت انجام شد.");

                NewResource(CommonConstants.FormattableMessages.Required, "ذکر {0} ضروری است.");
                NewResource(CommonConstants.FormattableMessages.InvalidLength, "حداکثر طول {0} {1} کاراکتر می باشد.");
                NewResource(CommonConstants.FormattableMessages.InvalidFormat, "قالب {0} وارد شده صحیح نمی باشد.");
                NewResource(CommonConstants.FormattableMessages.InvalidValue, "مقدار وارد شده برای {0} معتبر نمی باشد.");
                NewResource(CommonConstants.FormattableMessages.InvalidMinValue, "حداقل مقدار مجاز برای {0} {1} باشد.");
                NewResource(CommonConstants.FormattableMessages.InvalidMaxValue, "حداکثر مقدار مجاز برای {0} {1} باشد.");
                NewResource(CommonConstants.FormattableMessages.OutOfRangeValue, "مقدار مجاز برای {0} می بایست بین {1} و {2} باشد.");
                NewResource(CommonConstants.FormattableMessages.DuplicateValue, "{0} تکراری می باشد، لطفا {0} دیگری را تعیین کنید.");

                NewResource(CommonConstants.Fields.Metadata.Label, "متادیتا");

                transaction.Commit();
            }
        }
    }
}