using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Customer
{
    public class CustomerAvatarModel : BaseFaraModel
    {
        public string AvatarUrl { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}