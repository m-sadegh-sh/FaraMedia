using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Media
{
    public class PictureModel : BaseFaraModel
    {
        public string ImageUrl { get; set; }

        public string FullSizeImageUrl { get; set; }

        public string Title { get; set; }

        public string AlternateText { get; set; }
    }
}