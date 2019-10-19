using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using Fara.Web.Framework.Mvc;
using Fara.Web.Validators.Install;

namespace Fara.Web.Models.Install
{
    [Validator(typeof(InstallValidator))]
    public class InstallModel : BaseFaraModel
    {
        [AllowHtml]
        public string AdminEmail { get; set; }
        [AllowHtml]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
        [AllowHtml]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [AllowHtml]
        public string DatabaseConnectionString { get; set; }
        public string DataProvider { get; set; }
        
        public string SqlConnectionInfo { get; set; }
        [AllowHtml]
        public string SqlServerName { get; set; }
        [AllowHtml]
        public string SqlDatabaseName { get; set; }
        [AllowHtml]
        public string SqlServerUsername { get; set; }
        [AllowHtml]
        public string SqlServerPassword { get; set; }
        public string SqlAuthenticationType { get; set; }
        public bool SqlServerCreateDatabase { get; set; }



        public bool InstallSampleData { get; set; }
    }
}