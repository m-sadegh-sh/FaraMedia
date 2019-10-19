using System;
using System.Collections.Generic;
using Fara.Web.Framework;
using Fara.Web.Framework.Mvc;

namespace Fara.Web.Models.Customer
{
    public class CustomerRewardPointsModel : BaseFaraModel
    {
        public CustomerRewardPointsModel()
        {
            RewardPoints = new List<RewardPointsHistoryModel>();
        }

        public IList<RewardPointsHistoryModel> RewardPoints { get; set; }
        public string RewardPointsBalance { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }

        
        public class RewardPointsHistoryModel : BaseFaraEntityModel
        {
            [FaraResourceDisplayName("RewardPoints.Fields.Points")]
            public int Points { get; set; }

            [FaraResourceDisplayName("RewardPoints.Fields.PointsBalance")]
            public int PointsBalance { get; set; }

            [FaraResourceDisplayName("RewardPoints.Fields.Message")]
            public string Message { get; set; }

            [FaraResourceDisplayName("RewardPoints.Fields.Date")]
            public DateTime CreatedOn { get; set; }
        }

        
    }
}