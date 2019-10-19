namespace FaraMedia.Web.Framework.UI {
    using System.Xml;

    using FaraMedia.Core.Configuration;

    public class PageElementsConfig : ConfigBase {
        public static PageElementsConfig Load() {
            return Load<PageElementsConfig>();
        }

        public string AjaxLoadingElementId { get; set; }
        public string AjaxPlaceHolderElementId { get; set; }

        public override object Create(object parent, object configContext, XmlNode section) {
            var pageElementsConfig = new PageElementsConfig {
                AjaxLoadingElementId = GetAttribute(section,  "ajaxLoadingElementId", ""),
                AjaxPlaceHolderElementId = GetAttribute(section, "ajaxPlaceHolderElementId", "")
            };

            return pageElementsConfig;
        }
    }
}