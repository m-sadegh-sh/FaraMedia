using System.Collections.Generic;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Common
{
    public class StoreThemeSelectorModel : BaseFaraModel
    {
        public StoreThemeSelectorModel()
        {
            AvailableStoreThemes = new List<StoreThemeModel>();
        }

        public IList<StoreThemeModel> AvailableStoreThemes { get; set; }

        public StoreThemeModel CurrentStoreTheme { get; set; }
    }
}