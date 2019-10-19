namespace FaraMedia.Services.Installation.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Installation.Abstraction;

    using NHibernate;

    public sealed class BillingSettingsInstaller : SettingsInstallerBase {
        public override void InstallResources(IStatelessSession session) {
            UseSession(session);

            using (var transaction = session.BeginTransaction()) {
                NewResource(BillingSettingsConstants.Messages.PricePerTrackShouldNotBeGreaterThanPricePerAlbum, "قیمت هر قطعه نمی تواند از قیمت کل آلبوم بیشتر باشد.");
             
                NewResource(BillingSettingsConstants.Fields.PricePerTrack.Label, "قیمت هر قطعه");
                NewResource(BillingSettingsConstants.Fields.PublisherPercentagePerTrack.Label, "درصد فروش ناشر");
                NewResource(BillingSettingsConstants.Fields.PricePerAlbum.Label, "قیمت آلبوم");
                NewResource(BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.Label, "درصد فروش ناشر");
             
                NewResource(BillingSettingsConstants.Fields.Payer.Label, "پرداخت مالیات");
                NewResource(BillingSettingsConstants.Fields.Payer.ByPublisher, "بر عهده ناشر");
                NewResource(BillingSettingsConstants.Fields.Payer.ByUser, "بر عهده کاربر (خریدار)");
               
                NewResource(BillingSettingsConstants.Fields.MerchantId.Label, "شناسه تجاری");
                NewResource(BillingSettingsConstants.Fields.TransactionKey.Label, "شناسه تجاری");

                transaction.Commit();
            }
        }

        public override void InstallSettings() {
            EngineContext.Current.Resolve<IDbSettingsService<BillingSettings>>().Save(new BillingSettings {
                PricePerTrack = 200,
                PublisherPercentagePerTrack = 30.00M,
                PricePerAlbum = 2500,
                PublisherPercentagePerAlbum = 30.00M,

                Payer = TaxPayType.ByUser,

                MerchantId = "0123456789"
            });
        }
    }
}