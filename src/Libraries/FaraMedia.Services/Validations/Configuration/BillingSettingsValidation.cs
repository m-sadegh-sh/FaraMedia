namespace FaraMedia.Services.Validations.Configuration {
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Services.Validations.Extensions;

    using NHibernate.Validator.Cfg.Loquacious;

    public sealed class BillingSettingsValidation : ValidationDef<BillingSettings> {
        public BillingSettingsValidation() {
            Define(bs => bs.PricePerTrack)
                .GreaterThanOrEqualTo(BillingSettingsConstants.Fields.PricePerTrack.MinValue)
                .WithInvalidMinValue(BillingSettingsConstants.Fields.PricePerTrack.Label,
                                     BillingSettingsConstants.Fields.PricePerTrack.MinValue);

            Define(bs => bs.PublisherPercentagePerTrack)
                .IncludedBetween(BillingSettingsConstants.Fields.PublisherPercentagePerTrack.MinValue,
                                 BillingSettingsConstants.Fields.PublisherPercentagePerTrack.MaxValue)
                .WithInvalidRange(BillingSettingsConstants.Fields.PublisherPercentagePerTrack.Label,
                                  BillingSettingsConstants.Fields.PublisherPercentagePerTrack.MinValue,
                                  BillingSettingsConstants.Fields.PublisherPercentagePerTrack.MaxValue);

            Define(bs => bs.PricePerAlbum)
                .GreaterThanOrEqualTo(BillingSettingsConstants.Fields.PricePerAlbum.MinValue)
                .WithInvalidMinValue(BillingSettingsConstants.Fields.PricePerAlbum.Label,
                                     BillingSettingsConstants.Fields.PricePerAlbum.MinValue);

            Define(bs => bs.PublisherPercentagePerAlbum)
                .IncludedBetween(BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.MinValue,
                                 BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.MaxValue)
                .WithInvalidRange(BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.Label,
                                  BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.MinValue,
                                  BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.MaxValue);

            Define(bs => bs.MaximumAccessTries);

            Define(bs => bs.Payer);

            Define(bs => bs.MerchantId)
                .MaxLength();

            Define(bs => bs.TransactionKey)
                .MaxLength();

            ValidateInstance.SafeBy((billingSettings, context) => {
                                        var isValid = true;

                                        if (billingSettings.PricePerTrack > billingSettings.PricePerAlbum) {
                                            context.AddLocalizedInvalid<BillingSettings, decimal>(BillingSettingsConstants.Messages.PricePerTrackShouldNotBeGreaterThanPricePerAlbum,
                                                                                                  bs => bs.PricePerTrack);

                                            isValid = false;
                                        }

                                        return isValid;
                                    });
        }
    }
}