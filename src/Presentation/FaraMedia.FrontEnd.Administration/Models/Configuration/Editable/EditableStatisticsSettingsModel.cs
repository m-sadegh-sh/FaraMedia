namespace FaraMedia.FrontEnd.Administration.Models.Configuration {
    using FaraMedia.Data.Schemas.Configuration;
    using FaraMedia.Web.Framework.Mvc.Attributes;
    using FaraMedia.Web.Framework.Mvc.Models.Configuration;

    public class EditableMiscellaneousSettingsModel : EditableSettingsModelBase {
        [ResourceDisplayName(MiscellaneousSettingsConstants.Fields.ImmediatelyRedirection.Label)]
        public bool ImmediatelyRedirection { get; set; }

        [ResourceDisplayName(MiscellaneousSettingsConstants.Fields.DelayTime.Label)]
        [ResourceMin(MiscellaneousSettingsConstants.Fields.DelayTime.MinValue)]
        public int DelayTime { get; set; }
    }
}