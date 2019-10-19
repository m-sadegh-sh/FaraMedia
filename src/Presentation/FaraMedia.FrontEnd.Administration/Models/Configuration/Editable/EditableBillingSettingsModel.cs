namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using System.Web.Mvc;

    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableBillingSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(BillingSettingsConstants.Fields.PricePerTrack.Label)]
        [ResourceMin(BillingSettingsConstants.Fields.PricePerTrack.MinValue)]
        public decimal PricePerTrack { get; set; }

        [ResourceDisplayName(BillingSettingsConstants.Fields.PublisherPercentagePerTrack.Label)]
        [ResourceMin(BillingSettingsConstants.Fields.PublisherPercentagePerTrack.MinValue)]
        [ResourceMax(BillingSettingsConstants.Fields.PublisherPercentagePerTrack.MaxValue)]
        public decimal PublisherPercentagePerTrack { get; set; }

        [ResourceDisplayName(BillingSettingsConstants.Fields.PricePerAlbum.Label)]
        [ResourceMin(BillingSettingsConstants.Fields.PricePerAlbum.MinValue)]
        public decimal PricePerAlbum { get; set; }

        [ResourceDisplayName(BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.Label)]
        [ResourceMin(BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.MinValue)]
        [ResourceMax(BillingSettingsConstants.Fields.PublisherPercentagePerAlbum.MaxValue)]
        public decimal PublisherPercentagePerAlbum { get; set; }

        [ResourceDisplayName(BillingSettingsConstants.Fields.TaxPayType.Label)]
        [ResourceMin(BillingSettingsConstants.Fields.TaxPayType.MinValue)]
        [ResourceMax(BillingSettingsConstants.Fields.TaxPayType.MaxValue)]
        public int TaxPayType { get; set; }
        public SelectList AvailableTaxPayTypes { get; set; }

        [ResourceDisplayName(BillingSettingsConstants.Fields.MerchantId.Label)]
        public string MerchantId { get; set; }
    }
}