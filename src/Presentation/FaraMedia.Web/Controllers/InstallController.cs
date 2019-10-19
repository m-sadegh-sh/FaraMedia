using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Web.Hosting;
using System.Web.Mvc;
using Fara.Core;
using Fara.Core.Data;
using Fara.Core.Infrastructure;
using Fara.Core.Plugins;
using Fara.Services.Installation;
using Fara.Services.Security;
using Fara.Web.Models.Install;

namespace Fara.Web.Controllers
{
    public class InstallController : BaseFaraController
    {
        

        
        
        
        
        
        private bool sqlServerDatabaseExists(string connectionString)
        {
            try
            {
                
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        
        
        
        
        
        private string createDatabase(string connectionString)
        {
            try
            {
                
                var builder = new SqlConnectionStringBuilder(connectionString);
                var databaseName = builder.InitialCatalog;
                
                builder.InitialCatalog = "master";
                var masterCatalogConnectionString = builder.ToString();
                string query = string.Format("CREATE DATABASE [{0}] COLLATE SQL_Latin1_General_CP1_CI_AS", databaseName);

                using (var conn = new SqlConnection(masterCatalogConnectionString))
                {
                    conn.Open();
                    using (var command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();  
                    } 
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Format("An error occured when creating database: {0}", ex.Message);
            }
        }

        
        
        
        
        
        
        
        
        
        private bool checkPermissions(string path, bool checkRead, bool checkWrite, bool checkModify, bool checkDelete)
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            System.Security.AccessControl.AuthorizationRuleCollection rules = null;
            try
            {
                rules = Directory.GetAccessControl(path).GetAccessRules(true, true, typeof(SecurityIdentifier));
            }
            catch
            {
                return true;
            }
            try
            {
                foreach (FileSystemAccessRule rule in rules)
                {
                    if (!current.User.Equals(rule.IdentityReference))
                    {
                        continue;
                    }
                    if (AccessControlType.Deny.Equals(rule.AccessControlType))
                    {
                        if ((FileSystemRights.Delete & rule.FileSystemRights) == FileSystemRights.Delete)
                            flag4 = true;
                        if ((FileSystemRights.Modify & rule.FileSystemRights) == FileSystemRights.Modify)
                            flag3 = true;

                        if ((FileSystemRights.Read & rule.FileSystemRights) == FileSystemRights.Read)
                            flag = true;

                        if ((FileSystemRights.Write & rule.FileSystemRights) == FileSystemRights.Write)
                            flag2 = true;

                        continue;
                    }
                    if (AccessControlType.Allow.Equals(rule.AccessControlType))
                    {
                        if ((FileSystemRights.Delete & rule.FileSystemRights) == FileSystemRights.Delete)
                        {
                            flag8 = true;
                        }
                        if ((FileSystemRights.Modify & rule.FileSystemRights) == FileSystemRights.Modify)
                        {
                            flag7 = true;
                        }
                        if ((FileSystemRights.Read & rule.FileSystemRights) == FileSystemRights.Read)
                        {
                            flag5 = true;
                        }
                        if ((FileSystemRights.Write & rule.FileSystemRights) == FileSystemRights.Write)
                        {
                            flag6 = true;
                        }
                    }
                }
                foreach (IdentityReference reference in current.Groups)
                {
                    foreach (FileSystemAccessRule rule2 in rules)
                    {
                        if (!reference.Equals(rule2.IdentityReference))
                        {
                            continue;
                        }
                        if (AccessControlType.Deny.Equals(rule2.AccessControlType))
                        {
                            if ((FileSystemRights.Delete & rule2.FileSystemRights) == FileSystemRights.Delete)
                                flag4 = true;
                            if ((FileSystemRights.Modify & rule2.FileSystemRights) == FileSystemRights.Modify)
                                flag3 = true;
                            if ((FileSystemRights.Read & rule2.FileSystemRights) == FileSystemRights.Read)
                                flag = true;
                            if ((FileSystemRights.Write & rule2.FileSystemRights) == FileSystemRights.Write)
                                flag2 = true;
                            continue;
                        }
                        if (AccessControlType.Allow.Equals(rule2.AccessControlType))
                        {
                            if ((FileSystemRights.Delete & rule2.FileSystemRights) == FileSystemRights.Delete)
                                flag8 = true;
                            if ((FileSystemRights.Modify & rule2.FileSystemRights) == FileSystemRights.Modify)
                                flag7 = true;
                            if ((FileSystemRights.Read & rule2.FileSystemRights) == FileSystemRights.Read)
                                flag5 = true;
                            if ((FileSystemRights.Write & rule2.FileSystemRights) == FileSystemRights.Write)
                                flag6 = true;
                        }
                    }
                }
                bool flag9 = !flag4 && flag8;
                bool flag10 = !flag3 && flag7;
                bool flag11 = !flag && flag5;
                bool flag12 = !flag2 && flag6;
                bool flag13 = true;
                if (checkRead)
                {
                    flag13 = flag13 && flag11;
                }
                if (checkWrite)
                {
                    flag13 = flag13 && flag12;
                }
                if (checkModify)
                {
                    flag13 = flag13 && flag10;
                }
                if (checkDelete)
                {
                    flag13 = flag13 && flag9;
                }
                return flag13;
            }
            catch (IOException)
            {
            }
            return false;
        }

        
        
        
        
        
        
        
        
        
        
        private string createConnectionString(bool trustedConnection,
            string serverName, string databaseName, string userName, string password, int timeout = 0)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.IntegratedSecurity = trustedConnection;
            builder.DataSource = serverName;
            builder.InitialCatalog = databaseName;
            if (!trustedConnection)
            {
                builder.UserID = userName;
                builder.Password = password;
            }
            builder.PersistSecurityInfo = false;
            builder.MultipleActiveResultSets = true;
            if (timeout > 0)
            {
                builder.ConnectTimeout = timeout;
            }
            return builder.ConnectionString;
        }
        

        

        public ActionResult Index()
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
                return RedirectToAction("Index", "Home");

            
            this.Server.ScriptTimeout = 300;

            var model = new InstallModel()
            {
                AdminEmail = "admin@yourStore.com",
                
                
                InstallSampleData = true,
                DatabaseConnectionString = string.Empty,
                DataProvider = "sqlserver",
                SqlAuthenticationType = "sqlauthentication",
                SqlConnectionInfo = "sqlconnectioninfo_values",
                SqlServerCreateDatabase = false,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(InstallModel model)
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
                return RedirectToAction("Index", "Home");

            
            this.Server.ScriptTimeout = 300;

            if (model.DatabaseConnectionString != null)
                model.DatabaseConnectionString = model.DatabaseConnectionstring.Trim();

            
            if (model.DataProvider.Equals("sqlserver", StringComparison.InvariantCultureIgnoreCase))
            {
                if (model.SqlConnectionInfo.Equals("sqlconnectioninfo_raw", StringComparison.InvariantCultureIgnoreCase))
                {
                    
                    if (string.IsNullOrEmpty(model.DatabaseConnectionString))
                        ModelState.AddModelError(string.Empty, "A SQL connection string is required");

                    try
                    {
                        
                        new SqlConnectionStringBuilder(model.DatabaseConnectionString);
                    }
                    catch
                    {
                        ModelState.AddModelError(string.Empty, "Wrong SQL connection string format");
                    }
                }
                else
                {
                    
                    if (string.IsNullOrEmpty(model.SqlServerName))
                        ModelState.AddModelError(string.Empty, "SQL Server name is required");
                    if (string.IsNullOrEmpty(model.SqlDatabaseName))
                        ModelState.AddModelError(string.Empty, "Database name is required");

                    
                    if (model.SqlAuthenticationType.Equals("sqlauthentication", StringComparison.InvariantCultureIgnoreCase))
                    {
                        
                        if (string.IsNullOrEmpty(model.SqlServerUsername))
                            ModelState.AddModelError(string.Empty, "SQL Username is required");
                        if (string.IsNullOrEmpty(model.SqlServerPassword))
                            ModelState.AddModelError(string.Empty, "SQL Password is required");
                    }
                }
            }


            
            
            
            
            
            

            
            string rootDir = Server.MapPath("~/");
            var dirsToCheck = new List<string>();
            dirsToCheck.Add(rootDir);
            dirsToCheck.Add(rootDir + "App_Data");
            dirsToCheck.Add(rootDir + "bin");
            dirsToCheck.Add(rootDir + "content");
            dirsToCheck.Add(rootDir + "content\\images");
            dirsToCheck.Add(rootDir + "content\\images\\thumbs");
            dirsToCheck.Add(rootDir + "content\\files\\exportimport");
            dirsToCheck.Add(rootDir + "plugins");
            dirsToCheck.Add(rootDir + "plugins\\bin");
            foreach (string dir in dirsToCheck)
                if (!checkPermissions(dir, false, true, true, true))
                    ModelState.AddModelError(string.Empty, string.Format("The '{0}' account is not granted with Modify permission on folder '{1}'. Please configure these permissions.", WindowsIdentity.GetCurrent().Name, dir));

            var filesToCheck = new List<string>();
            filesToCheck.Add(rootDir + "Global.asax");
            filesToCheck.Add(rootDir + "web.config");
            filesToCheck.Add(rootDir + "App_Data\\InstalledPlugins.txt");
            filesToCheck.Add(rootDir + "App_Data\\Settings.txt");
            foreach (string file in filesToCheck)
                if (!checkPermissions(file, false, true, true, true))
                    ModelState.AddModelError(string.Empty, string.Format("The '{0}' account is not granted with Modify permission on file '{1}'. Please configure these permissions.", WindowsIdentity.GetCurrent().Name, file));
            
            if (ModelState.IsValid)
            {
                var settingsManager = new DataSettingsManager();
                try
                {
                    string connectionString = null;
                    if (model.DataProvider.Equals("sqlserver", StringComparison.InvariantCultureIgnoreCase))
                    {
                        

                        if (model.SqlConnectionInfo.Equals("sqlconnectioninfo_raw", StringComparison.InvariantCultureIgnoreCase))
                        {
                            
                            connectionString = model.DatabaseConnectionString;
                        }
                        else
                        {
                            
                            connectionString = createConnectionString(model.SqlAuthenticationType == "windowsauthentication",
                                model.SqlServerName, model.SqlDatabaseName,
                                model.SqlServerUsername, model.SqlServerPassword);
                        }
                        
                        if (model.SqlServerCreateDatabase)
                        {
                            if (!sqlServerDatabaseExists(connectionString))
                            {
                                
                                var errorCreatingDatabase = createDatabase(connectionString);
                                if (!string.IsNullOrEmpty(errorCreatingDatabase))
                                    throw new Exception(errorCreatingDatabase);
                                else
                                {
                                    
                                    
                                    Thread.Sleep(3000);
                                }
                            }
                        }
                        else
                        {
                            
                            if (!sqlServerDatabaseExists(connectionString))
                                throw new Exception("Database does not exist or you don't have permissions to connect to it");
                        }
                    }
                    else
                    {
                        
                        string databaseFileName = "Fara.Db.sdf";
                        string databasePath = @"|DataDirectory|\" + databaseFileName;
                        connectionString = "Data Source=" + databasePath + ";Persist Security Info=False";

                        
                        string databaseFullPath = HostingEnvironment.MapPath("~/App_Data/") + databaseFileName;
                        if (System.IO.File.Exists(databaseFullPath))
                        {
                            System.IO.File.Delete(databaseFullPath);
                        }
                    }

                    
                    var dataProvider = model.DataProvider;
                    var settings = new DataSettings()
                    {
                        DataProvider = dataProvider,
                        DataConnectionString = connectionString
                    };
                    settingsManager.SaveSettings(settings);

                    
                    var dataProviderInstance = EngineContext.Current.Resolve<BaseDataProviderManager>().LoadDataProvider();
                    dataProviderInstance.InitDatabase();
                    
                    
                    
                    var installationService = EngineContext.Current.Resolve<IInstallationService>();
                    installationService.InstallData(model.AdminEmail, model.AdminPassword, model.InstallSampleData);

                    
                    DataSettingsHelper.ResetCache();

                    
                    PluginManager.MarkAllPluginsAsUninstalled();
                    var pluginFinder = EngineContext.Current.Resolve<IPluginFinder>();
                    var plugins = pluginFinder.GetPlugins<IPlugin>(false)
                        .ToList()
                        .OrderBy(x => x.PluginDescriptor.Group)
                        .ThenBy(x => x.PluginDescriptor.DisplayOrder)
                        .ToList();
                    foreach (var plugin in plugins)
                    {
                        plugin.Install();
                    }
                    
                    
                    
                    var permissionProviders = new List<Type>();
                    permissionProviders.Add(typeof(StandardPermissionProvider));
                    foreach (var providerType in permissionProviders)
                    {
                        dynamic provider = Activator.CreateInstance(providerType);
                        EngineContext.Current.Resolve<IPermissionService>().InstallPermissions(provider);
                    }

                    
                    var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                    webHelper.RestartAppDomain();

                    
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception exception)
                {
                    
                    DataSettingsHelper.ResetCache();

                    
                    settingsManager.SaveSettings(new DataSettings
                    {
                        DataProvider = null,
                        DataConnectionString = null
                    });
                    
                    ModelState.AddModelError(string.Empty, "Setup failed: " + exception);
                }
            }
            return View(model);
        }

        public ActionResult RestartInstall()
        {
            if (DataSettingsHelper.DatabaseIsInstalled())
                return RedirectToAction("Index", "Home");
            
            
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            webHelper.RestartAppDomain("~/Install/Index");

            
            return RedirectToAction("Index", "Home");
        }

        
    }
}
