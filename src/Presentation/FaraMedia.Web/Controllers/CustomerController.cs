﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fara.Core;
using Fara.Core.Domain.Customers;
using Fara.Core.Domain.Directory;
using Fara.Core.Domain.Forums;
using Fara.Core.Domain.Localization;
using Fara.Core.Domain.Media;
using Fara.Core.Domain.Messages;
using Fara.Core.Domain.Orders;
using Fara.Core.Domain.Tax;
using Fara.Services.Authentication;
using Fara.Services.Authentication.External;
using Fara.Services.Catalog;
using Fara.Services.Common;
using Fara.Services.Customers;
using Fara.Services.Directory;
using Fara.Services.Forums;
using Fara.Services.Helpers;
using Fara.Services.Localization;
using Fara.Services.Media;
using Fara.Services.Messages;
using Fara.Services.Orders;
using Fara.Services.Seo;
using Fara.Services.Tax;
using Fara.Web.Extensions;
using Fara.Web.Framework.Controllers;
using Fara.Web.Framework.Security;
using Fara.Web.Framework.UI.Captcha;
using Fara.Web.Models;
using Fara.Web.Models.Common;
using Fara.Web.Models.Customer;

namespace Fara.Web.Controllers
{
    public class CustomerController : BaseFaraController
    {
        
        private readonly IAuthenticationService _authenticationService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly DateTimeSettings _dateTimeSettings;
        private readonly TaxSettings _taxSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly ICustomerService _customerService;
        private readonly ITaxService _taxService;
        private readonly RewardPointsSettings _rewardPointsSettings;
        private readonly CustomerSettings _customerSettings;
        private readonly ForumSettings _forumSettings;
        private readonly OrderSettings _orderSettings;
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IOrderTotalCalculationService _orderTotalCalculationService;
        private readonly IOrderProcessingService _orderProcessingService;
        private readonly IOrderService _orderService;
        private readonly ICurrencyService _currencyService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IPictureService _pictureService;
        private readonly INewsLetterSubscriptionService _newsLetterSubscriptionService;
        private readonly IForumService _forumService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOpenAuthenticationService _openAuthenticationService;
        private readonly IBackInStockSubscriptionService _backInStockSubscriptionService;

        private readonly MediaSettings _mediaSettings;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CaptchaSettings _captchaSettings;
        private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;

        

        

        public CustomerController(IAuthenticationService authenticationService,
            IDateTimeHelper dateTimeHelper,
            DateTimeSettings dateTimeSettings, TaxSettings taxSettings,
            ILocalizationService localizationService,
            IWorkContext workContext, ICustomerService customerService,
            ITaxService taxService, RewardPointsSettings rewardPointsSettings,
            CustomerSettings customerSettings, ForumSettings forumSettings,
            OrderSettings orderSettings, IAddressService addressService,
            ICountryService countryService, IStateProvinceService stateProvinceService,
            IOrderTotalCalculationService orderTotalCalculationService,
            IOrderProcessingService orderProcessingService, IOrderService orderService,
            ICurrencyService currencyService, IPriceFormatter priceFormatter,
            IPictureService pictureService, INewsLetterSubscriptionService newsLetterSubscriptionService,
            IForumService forumService, IShoppingCartService shoppingCartService,
            IOpenAuthenticationService openAuthenticationService, 
            IBackInStockSubscriptionService backInStockSubscriptionService, MediaSettings mediaSettings,
            IWorkflowMessageService workflowMessageService, LocalizationSettings localizationSettings,
            CaptchaSettings captchaSettings, ExternalAuthenticationSettings externalAuthenticationSettings)
        {
            this._authenticationService = authenticationService;
            this._dateTimeHelper = dateTimeHelper;
            this._dateTimeSettings = dateTimeSettings;
            this._taxSettings = taxSettings;
            this._localizationService = localizationService;
            this._workContext = workContext;
            this._customerService = customerService;
            this._taxService = taxService;
            this._rewardPointsSettings = rewardPointsSettings;
            this._customerSettings = customerSettings;
            this._forumSettings = forumSettings;
            this._orderSettings = orderSettings;
            this._addressService = addressService;
            this._countryService = countryService;
            this._stateProvinceService = stateProvinceService;
            this._orderProcessingService = orderProcessingService;
            this._orderTotalCalculationService = orderTotalCalculationService;
            this._orderService = orderService;
            this._currencyService = currencyService;
            this._priceFormatter = priceFormatter;
            this._pictureService = pictureService;
            this._newsLetterSubscriptionService = newsLetterSubscriptionService;
            this._forumService = forumService;
            this._shoppingCartService = shoppingCartService;
            this._openAuthenticationService = openAuthenticationService;
            this._backInStockSubscriptionService = backInStockSubscriptionService;

            this._mediaSettings = mediaSettings;
            this._workflowMessageService = workflowMessageService;
            this._localizationSettings = localizationSettings;
            this._captchaSettings = captchaSettings;
            this._externalAuthenticationSettings = externalAuthenticationSettings;
        }

        

        

        [NonAction]
        private bool IsCurrentUserRegistered()
        {
            return _workContext.CurrentCustomer.IsRegistered();
        }

        [NonAction]
        private CustomerNavigationModel GetCustomerNavigationModel(Customer customer)
        {
            var model = new CustomerNavigationModel();
            model.HideAvatar = !_customerSettings.AllowCustomersToUploadAvatars;
            model.HideRewardPoints = !_rewardPointsSettings.Enabled;
            model.HideForumSubscriptions = !_forumSettings.ForumsEnabled || !_forumSettings.AllowCustomersToManageSubscriptions;
            model.HideReturnRequests = !_orderSettings.ReturnRequestsEnabled || _orderService.SearchReturnRequests(customer.Id, 0, null).Count == 0;
            model.HideDownloadableProducts = _customerSettings.HideDownloadableProductsTab;
            model.HideBackInStockSubscriptions = _customerSettings.HideBackInStockSubscriptionsTab;
            return model;
        }

        [NonAction]
        private void TryAssociateAccountWithExternalAccount(Customer customer)
        {
            var parameters = ExternalAuthorizerHelper.RetrieveParametersFromRoundTrip(true);
            if (parameters == null)
                return;

            if (_openAuthenticationService.AccountExists(parameters))
                return;

            _openAuthenticationService.AssociateExternalAccountWithUser(customer, parameters);
        }

        

        
        
        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Login(bool? checkoutAsGuest)
        {
            var model = new LoginModel();
            model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
            model.CheckoutAsGuest = checkoutAsGuest.HasValue ? checkoutAsGuest.Value : false;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_customerSettings.UsernamesEnabled && model.Username != null)
                {
                    model.Username = model.Username.Trim();
                }

                if (_customerService.ValidateCustomer(_customerSettings.UsernamesEnabled ? model.Username : model.Email, model.Password))
                {
                    var customer = _customerSettings.UsernamesEnabled ? _customerService.GetCustomerByUsername(model.Username) : _customerService.GetCustomerByEmail(model.Email);

                    
                    _shoppingCartService.MigrateShoppingCart(_workContext.CurrentCustomer, customer);

                    
                    _authenticationService.SignIn(customer, model.RememberMe);


                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, _localizationService.GetResource("Account.Login.WrongCredentials"));
                }
            }

            
            model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
            return View(model);
        }

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Register()
        {
            
            if (_customerSettings.UserRegistrationType == UserRegistrationType.Disabled)
                return RedirectToRoute("RegisterResult", new { resultId = (int)UserRegistrationType.Disabled });

            var model = new RegisterModel();
            model.AllowCustomersToSetTimeZone = _dateTimeSettings.AllowCustomersToSetTimeZone;
            foreach (var tzi in _dateTimeHelper.GetSystemTimeZones())
                model.AvailableTimeZones.Add(new SelectListItem() { Text = tzi.DisplayName, Value = tzi.Id, Selected = (tzi.Id == _dateTimeHelper.DefaultStoreTimeZone.Id) });
            model.DisplayVatNumber = _taxSettings.EuVatEnabled;
            
            model.GenderEnabled = _customerSettings.GenderEnabled;
            model.DateOfBirthEnabled = _customerSettings.DateOfBirthEnabled;
            model.CompanyEnabled = _customerSettings.CompanyEnabled;
            model.StreetAddressEnabled = _customerSettings.StreetAddressEnabled;
            model.StreetAddress2Enabled = _customerSettings.StreetAddress2Enabled;
            model.ZipPostalCodeEnabled = _customerSettings.ZipPostalCodeEnabled;
            model.CityEnabled = _customerSettings.CityEnabled;
            model.CountryEnabled = _customerSettings.CountryEnabled;
            model.StateProvinceEnabled = _customerSettings.StateProvinceEnabled;
            model.PhoneEnabled = _customerSettings.PhoneEnabled;
            model.FaxEnabled = _customerSettings.FaxEnabled;
            model.NewsletterEnabled = _customerSettings.NewsletterEnabled;
            model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
            model.CheckUsernameAvailabilityEnabled = _customerSettings.CheckUsernameAvailabilityEnabled;
            model.DisplayCaptcha = _captchaSettings.Enabled;
            if (_customerSettings.CountryEnabled)
            {
                model.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });
                foreach (var c in _countryService.GetAllCountries())
                {
                    model.AvailableCountries.Add(new SelectListItem() { Text = c.GetLocalized(x => x.Name), Value = c.Id.ToString() });
                }
                
                if (_customerSettings.StateProvinceEnabled)
                {
                    
                    var states = _stateProvinceService.GetStateProvincesByCountryId(model.CountryId).ToList();
                    if (states.Count > 0)
                    {
                        foreach (var s in states)
                            model.AvailableStates.Add(new SelectListItem() { Text = s.GetLocalized(x => x.Name), Value = s.Id.ToString(), Selected = (s.Id == model.StateProvinceId) });
                    }
                    else
                        model.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.OtherNonUS"), Value = "0" });

                }
            }

            return View(model);
        }

        [HttpPost]
        [CaptchaValidator]
        public ActionResult Register(RegisterModel model, bool? captchaValid)
        {
            
            if (_customerSettings.UserRegistrationType == UserRegistrationType.Disabled)
                return RedirectToRoute("RegisterResult", new { resultId = (int)UserRegistrationType.Disabled });
            
            if (_workContext.CurrentCustomer.IsRegistered())
            {
                
                _authenticationService.SignOut();
                
                
                _workContext.CurrentCustomer = _customerService.InsertGuestCustomer();
            }
            var customer = _workContext.CurrentCustomer;


            if (captchaValid.HasValue && !captchaValid.Value)
                ModelState.AddModelError(string.Empty, _localizationService.GetResource("Common.WrongCaptcha"));

            if (ModelState.IsValid)
            {
                if (_customerSettings.UsernamesEnabled && model.Username != null)
                {
                    model.Username = model.Username.Trim();
                }

                bool isApproved = _customerSettings.UserRegistrationType == UserRegistrationType.Standard;
                var registrationRequest = new CustomerRegistrationRequest(customer, model.Email,
                    _customerSettings.UsernamesEnabled ? model.Username : model.Email, model.Password, PasswordFormat.Hashed, isApproved);
                var registrationResult = _customerService.RegisterCustomer(registrationRequest);
                if (registrationResult.Success)
                {
                    
                    if (_dateTimeSettings.AllowCustomersToSetTimeZone)
                        customer.TimeZoneId = model.TimeZoneId;
                    
                    if (_taxSettings.EuVatEnabled)
                    {
                        customer.VatNumber = model.VatNumber;
                        
                        string vatName = string.Empty;
                        string vatAddress = string.Empty;
                        customer.VatNumberStatus = _taxService.GetVatNumberStatus(customer.VatNumber, out vatName, out vatAddress);
                        
                        if (!string.IsNullOrEmpty(customer.VatNumber) && _taxSettings.EuVatEmailAdminWhenNewVatSubmitted)
                            _workflowMessageService.SendNewVatSubmittedStoreOwnerNotification(customer, customer.VatNumber, vatAddress, _localizationSettings.DefaultAdminLanguageId);

                    }
                    
                    _customerService.UpdateCustomer(customer);

                    
                    if (_customerSettings.GenderEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Gender, model.Gender);
                    _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.FirstName, model.FirstName);
                    _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.LastName, model.LastName);
                    if (_customerSettings.DateOfBirthEnabled)
                    {
                        DateTime? dateOfBirth = null;
                        try
                        {
                            dateOfBirth = new DateTime(model.DateOfBirthYear.Value, model.DateOfBirthMonth.Value, model.DateOfBirthDay.Value);
                        }
                        catch { }
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.DateOfBirth, dateOfBirth);
                    }
                    if (_customerSettings.CompanyEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Company, model.Company);
                    if (_customerSettings.StreetAddressEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.StreetAddress, model.StreetAddress);
                    if (_customerSettings.StreetAddress2Enabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.StreetAddress2, model.StreetAddress2);
                    if (_customerSettings.ZipPostalCodeEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.ZipPostalCode, model.ZipPostalCode);
                    if (_customerSettings.CityEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.City, model.City);
                    if (_customerSettings.CountryEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.CountryId, model.CountryId);
                    if (_customerSettings.CountryEnabled && _customerSettings.StateProvinceEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.StateProvinceId, model.StateProvinceId);
                    if (_customerSettings.PhoneEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Phone, model.Phone);
                    if (_customerSettings.FaxEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Fax, model.Fax);

                    
                    if (_customerSettings.NewsletterEnabled)
                    {
                        
                        var newsletter = _newsLetterSubscriptionService.GetNewsLetterSubscriptionByEmail(model.Email);
                        if (newsletter != null)
                        {
                            if (model.Newsletter)
                            {
                                newsletter.Active = true;
                                _newsLetterSubscriptionService.UpdateNewsLetterSubscription(newsletter);
                            }
                            else
                                _newsLetterSubscriptionService.DeleteNewsLetterSubscription(newsletter);
                        }
                        else
                        {
                            if (model.Newsletter)
                            {
                                _newsLetterSubscriptionService.InsertNewsLetterSubscription(new NewsLetterSubscription()
                                {
                                    NewsLetterSubscriptionGuid = Guid.NewGuid(),
                                    Email = model.Email,
                                    Active = true,
                                    CreatedOnUtc = DateTime.UtcNow
                                });
                            }
                        }
                    }

                    
                    if (isApproved)
                        _authenticationService.SignIn(customer, true);

                    
                    TryAssociateAccountWithExternalAccount(customer);
                    

                    
                    if (_customerSettings.NotifyNewCustomerRegistration)
                        _workflowMessageService.SendCustomerRegisteredNotificationMessage(customer, _localizationSettings.DefaultAdminLanguageId);
                    
                    switch (_customerSettings.UserRegistrationType)
                    {
                        case UserRegistrationType.EmailValidation:
                            {
                                
                                _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.AccountActivationToken, Guid.NewGuid().ToString());
                                _workflowMessageService.SendCustomerEmailValidationMessage(customer, _workContext.WorkingLanguage.Id);

                                
                                return RedirectToRoute("RegisterResult", new { resultId = (int)UserRegistrationType.EmailValidation });
                            }
                        case UserRegistrationType.AdminApproval:
                            {
                                return RedirectToRoute("RegisterResult", new { resultId = (int)UserRegistrationType.AdminApproval });
                            }
                        case UserRegistrationType.Standard:
                            {
                                
                                _workflowMessageService.SendCustomerWelcomeMessage(customer, _workContext.WorkingLanguage.Id);

                                return RedirectToRoute("RegisterResult", new { resultId = (int)UserRegistrationType.Standard });
                            }
                        default:
                            {
                                return RedirectToAction("Index", "Home");
                            }
                    }
                }
                else
                {
                    foreach (var error in registrationResult.Errors)
                        ModelState.AddModelError(string.Empty, error);
                }
            }

            
            model.AllowCustomersToSetTimeZone = _dateTimeSettings.AllowCustomersToSetTimeZone;
            foreach (var tzi in _dateTimeHelper.GetSystemTimeZones())
                model.AvailableTimeZones.Add(new SelectListItem() { Text = tzi.DisplayName, Value = tzi.Id, Selected = (tzi.Id == _dateTimeHelper.DefaultStoreTimeZone.Id) });
            model.DisplayVatNumber = _taxSettings.EuVatEnabled;
            
            model.GenderEnabled = _customerSettings.GenderEnabled;
            model.DateOfBirthEnabled = _customerSettings.DateOfBirthEnabled;
            model.CompanyEnabled = _customerSettings.CompanyEnabled;
            model.StreetAddressEnabled = _customerSettings.StreetAddressEnabled;
            model.StreetAddress2Enabled = _customerSettings.StreetAddress2Enabled;
            model.ZipPostalCodeEnabled = _customerSettings.ZipPostalCodeEnabled;
            model.CityEnabled = _customerSettings.CityEnabled;
            model.CountryEnabled = _customerSettings.CountryEnabled;
            model.StateProvinceEnabled = _customerSettings.StateProvinceEnabled;
            model.PhoneEnabled = _customerSettings.PhoneEnabled;
            model.FaxEnabled = _customerSettings.FaxEnabled;
            model.NewsletterEnabled = _customerSettings.NewsletterEnabled;
            model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
            model.CheckUsernameAvailabilityEnabled = _customerSettings.CheckUsernameAvailabilityEnabled;
            model.DisplayCaptcha = _captchaSettings.Enabled;
            if (_customerSettings.CountryEnabled)
            {
                model.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });
                foreach (var c in _countryService.GetAllCountries())
                {
                    model.AvailableCountries.Add(new SelectListItem() { Text = c.GetLocalized(x => x.Name), Value = c.Id.ToString(), Selected = (c.Id == model.CountryId) });
                }


                if (_customerSettings.StateProvinceEnabled)
                {
                    
                    var states = _stateProvinceService.GetStateProvincesByCountryId(model.CountryId).ToList();
                    if (states.Count > 0)
                    {
                        foreach (var s in states)
                            model.AvailableStates.Add(new SelectListItem() { Text = s.GetLocalized(x => x.Name), Value = s.Id.ToString(), Selected = (s.Id == model.StateProvinceId) });
                    }
                    else
                        model.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.OtherNonUS"), Value = "0" });

                }
            }

            return View(model);
        }

        public ActionResult RegisterResult(int resultId)
        {
            var resultText = string.Empty;
            switch ((UserRegistrationType)resultId)
            {
                case UserRegistrationType.Disabled:
                    resultText = _localizationService.GetResource("Account.Register.Result.Disabled");
                    break;
                case UserRegistrationType.Standard:
                    resultText = _localizationService.GetResource("Account.Register.Result.Standard");
                    break;
                case UserRegistrationType.AdminApproval:
                    resultText = _localizationService.GetResource("Account.Register.Result.AdminApproval");
                    break;
                case UserRegistrationType.EmailValidation:
                    resultText = _localizationService.GetResource("Account.Register.Result.EmailValidation");
                    break;
                default:
                    break;
            }
            var model = new RegisterResultModel()
            {
                Result = resultText
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CheckUsernameAvailability(string username)
        {
            var usernameAvailable = false;
            var statusText = _localizationService.GetResource("Account.CheckUsernameAvailability.NotAvailable");

            if (_customerSettings.UsernamesEnabled && username != null)
            {
                username = username.Trim();

                if (UsernameIsValid(username))
                {
                    if (_workContext.CurrentCustomer != null && 
                        _workContext.CurrentCustomer.Username != null && 
                        _workContext.CurrentCustomer.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                    {
                        statusText = _localizationService.GetResource("Account.CheckUsernameAvailability.CurrentUsername");
                    }
                    else
                    {
                        var customer = _customerService.GetCustomerByUsername(username);
                        if (customer == null)
                        {
                            statusText = _localizationService.GetResource("Account.CheckUsernameAvailability.Available");
                            usernameAvailable = true;
                        }
                    }
                }
            }

            return Json(new { Available = usernameAvailable, Text = statusText });
        }

        [NonAction]
        public bool UsernameIsValid(string username)
        {
            var result = true;

            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            

            return result;
        }


        public ActionResult Logout()
        {
            
            ExternalAuthorizerHelper.RemoveParameters();

            if (_workContext.OriginalCustomerIfImpersonated != null)
            {
                
                _customerService.SaveCustomerAttribute<int?>(_workContext.OriginalCustomerIfImpersonated,
                    SystemCustomerAttributeNames.ImpersonatedCustomerId, null);
                
                return this.RedirectToAction("Edit", "Customer", new { id = _workContext.CurrentCustomer.Id, area = "Admin" });

            }
            else
            {
                
                _authenticationService.SignOut();
                return this.RedirectToAction("Index", "Home");
            }

        }

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult AccountActivation(string token, string email)
        {
            var customer = _customerService.GetCustomerByEmail(email);
            if (customer == null)
                return RedirectToAction("Index", "Home");

            var cToken = customer.GetAttribute<string>(SystemCustomerAttributeNames.AccountActivationToken);
            if (string.IsNullOrEmpty(cToken))
                return RedirectToAction("Index", "Home");

            if (!cToken.Equals(token, StringComparison.InvariantCultureIgnoreCase))
                return RedirectToAction("Index", "Home");

            
            customer.Active = true;
            _customerService.UpdateCustomer(customer);
            _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.AccountActivationToken, string.Empty);
            
            _workflowMessageService.SendCustomerWelcomeMessage(customer, _workContext.WorkingLanguage.Id);
            
            var model = new AccountActivationModel();
            model.Result = _localizationService.GetResource("Account.AccountActivation.Activated");
            return View(model);
        }

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult MyAccount()
        {
            return RedirectToAction("info");
        }

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Info()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            var model = new CustomerInfoModel();
            PrepareCustomerInfoModel(model, customer, false);

            return View(model);
        }

        [HttpPost]        
        public ActionResult Info(CustomerInfoModel model)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError(string.Empty, "Email is not provided.");
            
            if (_customerSettings.UsernamesEnabled &&
                this._customerSettings.AllowUsersToChangeUsernames)
            {
                if (string.IsNullOrEmpty(model.Username))
                    ModelState.AddModelError(string.Empty, "Username is not provided.");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    
                    if (_customerSettings.UsernamesEnabled &&
                        this._customerSettings.AllowUsersToChangeUsernames)
                    {
                        if (!customer.Username.Equals(model.Username.Trim(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            
                            _customerService.SetUsername(customer, model.Username.Trim());
                            
                            _authenticationService.SignIn(customer, true);
                        }
                    }
                    
                    if (!customer.Email.Equals(model.Email.Trim(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        
                        _customerService.SetEmail(customer, model.Email.Trim());
                        
                        if (!_customerSettings.UsernamesEnabled)
                        {
                            _authenticationService.SignIn(customer, true);
                        }
                    }

                    
                    if (_dateTimeSettings.AllowCustomersToSetTimeZone)
                        customer.TimeZoneId = model.TimeZoneId;
                    
                    if (_taxSettings.EuVatEnabled)
                    {
                        var prevVatNumber = customer.VatNumber;
                        customer.VatNumber = model.VatNumber;
                        if (prevVatNumber != model.VatNumber)
                        {
                            string vatName = string.Empty;
                            string vatAddress = string.Empty;
                            customer.VatNumberStatus = _taxService.GetVatNumberStatus(customer.VatNumber, out vatName, out vatAddress);
                            
                            if (!string.IsNullOrEmpty(customer.VatNumber) && _taxSettings.EuVatEmailAdminWhenNewVatSubmitted)
                                _workflowMessageService.SendNewVatSubmittedStoreOwnerNotification(customer, customer.VatNumber, vatAddress, _localizationSettings.DefaultAdminLanguageId);
                        }
                    }
                    
                    _customerService.UpdateCustomer(customer);

                    
                    if (_customerSettings.GenderEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Gender, model.Gender);
                    _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.FirstName, model.FirstName);
                    _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.LastName, model.LastName);
                    if (_customerSettings.DateOfBirthEnabled)
                    {
                        DateTime? dateOfBirth = null;
                        try
                        {
                            dateOfBirth = new DateTime(model.DateOfBirthYear.Value, model.DateOfBirthMonth.Value, model.DateOfBirthDay.Value);
                        }
                        catch { }
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.DateOfBirth, dateOfBirth);
                    }
                    if (_customerSettings.CompanyEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Company, model.Company);
                    if (_customerSettings.StreetAddressEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.StreetAddress, model.StreetAddress);
                    if (_customerSettings.StreetAddress2Enabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.StreetAddress2, model.StreetAddress2);
                    if (_customerSettings.ZipPostalCodeEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.ZipPostalCode, model.ZipPostalCode);
                    if (_customerSettings.CityEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.City, model.City);
                    if (_customerSettings.CountryEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.CountryId, model.CountryId);
                    if (_customerSettings.CountryEnabled && _customerSettings.StateProvinceEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.StateProvinceId, model.StateProvinceId);
                    if (_customerSettings.PhoneEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Phone, model.Phone);
                    if (_customerSettings.FaxEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Fax, model.Fax);

                    
                    if (_customerSettings.NewsletterEnabled)
                    {
                        
                        var newsletter = _newsLetterSubscriptionService.GetNewsLetterSubscriptionByEmail(customer.Email);
                        if (newsletter != null)
                        {
                            if (model.Newsletter)
                            {
                                newsletter.Active = true;
                                _newsLetterSubscriptionService.UpdateNewsLetterSubscription(newsletter);
                            }
                            else
                                _newsLetterSubscriptionService.DeleteNewsLetterSubscription(newsletter);
                        }
                        else
                        {
                            if (model.Newsletter)
                            {
                                _newsLetterSubscriptionService.InsertNewsLetterSubscription(new NewsLetterSubscription()
                                {
                                    NewsLetterSubscriptionGuid = Guid.NewGuid(),
                                    Email = customer.Email,
                                    Active = true,
                                    CreatedOnUtc = DateTime.UtcNow
                                });
                            }
                        }
                    }

                    if (_forumSettings.ForumsEnabled && _forumSettings.SignaturesEnabled)
                        _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.Signature, model.Signature);

                    return RedirectToAction("info");
                }
            }
            catch (Exception exc)
            {
                ModelState.AddModelError(string.Empty, exc.Message);
            }


            
            PrepareCustomerInfoModel(model, customer, true);
            return View(model);
        }
        
        [NonAction]
        private void PrepareCustomerInfoModel(CustomerInfoModel model, Customer customer, bool excludeProperties)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (customer == null)
                throw new ArgumentNullException("customer");
            
            model.AllowCustomersToSetTimeZone = _dateTimeSettings.AllowCustomersToSetTimeZone;
            foreach (var tzi in _dateTimeHelper.GetSystemTimeZones())
                model.AvailableTimeZones.Add(new SelectListItem() { Text = tzi.DisplayName, Value = tzi.Id, Selected = (excludeProperties ? tzi.Id == model.TimeZoneId : tzi.Id == _dateTimeHelper.CurrentTimeZone.Id) });
            
            if (!excludeProperties)
            {
                model.VatNumber = customer.VatNumber;
                model.FirstName = customer.GetAttribute<string>(SystemCustomerAttributeNames.FirstName);
                model.LastName = customer.GetAttribute<string>(SystemCustomerAttributeNames.LastName);
                model.Gender = customer.GetAttribute<string>(SystemCustomerAttributeNames.Gender);
                var dateOfBirth = customer.GetAttribute<DateTime?>(SystemCustomerAttributeNames.DateOfBirth);
                if (dateOfBirth.HasValue)
                {
                    model.DateOfBirthDay = dateOfBirth.Value.Day;
                    model.DateOfBirthMonth = dateOfBirth.Value.Month;
                    model.DateOfBirthYear = dateOfBirth.Value.Year;
                }
                model.Company = customer.GetAttribute<string>(SystemCustomerAttributeNames.Company);
                model.StreetAddress = customer.GetAttribute<string>(SystemCustomerAttributeNames.StreetAddress);
                model.StreetAddress2 = customer.GetAttribute<string>(SystemCustomerAttributeNames.StreetAddress2);
                model.ZipPostalCode = customer.GetAttribute<string>(SystemCustomerAttributeNames.ZipPostalCode);
                model.City = customer.GetAttribute<string>(SystemCustomerAttributeNames.City);
                model.CountryId = customer.GetAttribute<int>(SystemCustomerAttributeNames.CountryId);
                model.StateProvinceId = customer.GetAttribute<int>(SystemCustomerAttributeNames.StateProvinceId);
                model.Phone = customer.GetAttribute<string>(SystemCustomerAttributeNames.Phone);
                model.Fax = customer.GetAttribute<string>(SystemCustomerAttributeNames.Fax);

                
                var newsletter = _newsLetterSubscriptionService.GetNewsLetterSubscriptionByEmail(customer.Email);
                model.Newsletter = newsletter != null && newsletter.Active;

                model.Signature = customer.GetAttribute<string>(SystemCustomerAttributeNames.Signature);

                model.Email = customer.Email;
                model.Username = customer.Username;
            }
            else
            {
                if (_customerSettings.UsernamesEnabled && !_customerSettings.AllowUsersToChangeUsernames)
                    model.Username = customer.Username;
            }

            
            if (_customerSettings.CountryEnabled)
            {
                model.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });
                foreach (var c in _countryService.GetAllCountries())
                {
                    model.AvailableCountries.Add(new SelectListItem()
                    {
                        Text = c.GetLocalized(x => x.Name),
                        Value = c.Id.ToString(),
                        Selected = c.Id == model.CountryId
                    });
                }

                if (_customerSettings.StateProvinceEnabled)
                {
                    
                    var states = _stateProvinceService.GetStateProvincesByCountryId(model.CountryId).ToList();
                    if (states.Count > 0)
                    {
                        foreach (var s in states)
                            model.AvailableStates.Add(new SelectListItem() { Text = s.GetLocalized(x => x.Name), Value = s.Id.ToString(), Selected = (s.Id == model.StateProvinceId) });
                    }
                    else
                        model.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.OtherNonUS"), Value = "0" });

                }
            }
            model.DisplayVatNumber = _taxSettings.EuVatEnabled;
            model.VatNumberStatusNote = customer.VatNumberStatus.GetLocalizedEnum(_localizationService, _workContext);
            model.GenderEnabled = _customerSettings.GenderEnabled;
            model.DateOfBirthEnabled = _customerSettings.DateOfBirthEnabled;
            model.CompanyEnabled = _customerSettings.CompanyEnabled;
            model.StreetAddressEnabled = _customerSettings.StreetAddressEnabled;
            model.StreetAddress2Enabled = _customerSettings.StreetAddress2Enabled;
            model.ZipPostalCodeEnabled = _customerSettings.ZipPostalCodeEnabled;
            model.CityEnabled = _customerSettings.CityEnabled;
            model.CountryEnabled = _customerSettings.CountryEnabled;
            model.StateProvinceEnabled = _customerSettings.StateProvinceEnabled;
            model.PhoneEnabled = _customerSettings.PhoneEnabled;
            model.FaxEnabled = _customerSettings.FaxEnabled;
            model.NewsletterEnabled = _customerSettings.NewsletterEnabled;
            model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
            model.AllowUsersToChangeUsernames = _customerSettings.AllowUsersToChangeUsernames;
            model.CheckUsernameAvailabilityEnabled = _customerSettings.CheckUsernameAvailabilityEnabled;
            model.SignatureEnabled = _forumSettings.ForumsEnabled && _forumSettings.SignaturesEnabled;

            
            foreach (var ear in _openAuthenticationService.GetExternalIdentifiersFor(customer))
            {
                var authMethod = _openAuthenticationService.LoadExternalAuthenticationMethodBySystemName(ear.ProviderSystemName);
                if (authMethod == null || !authMethod.IsMethodActive(_externalAuthenticationSettings))
                    continue;

                model.AssociatedExternalAuthRecords.Add(new CustomerInfoModel.AssociatedExternalAuthModel()
                {
                    Id = ear.Id,
                    Email = ear.Email,
                    ExternalIdentifier = ear.ExternalIdentifier,
                    AuthMethodName = authMethod.PluginDescriptor.FriendlyName
                });
            }


            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Info;
        }

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Addresses()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            var model = new CustomerAddressListModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Addresses;
            foreach (var address in customer.Addresses)
                model.Addresses.Add(address.ToModel());
            return View(model);
        }

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult AddressDelete(int addressId)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            
            var address = customer.Addresses.Where(a => a.Id == addressId).FirstOrDefault();
            if (address != null)
            {
                customer.RemoveAddress(address);
                _customerService.UpdateCustomer(customer);
                
                _addressService.DeleteAddress(address);
            }

            return RedirectToAction("Addresses");
        }

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult AddressAdd()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            var model = new CustomerAddressEditModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Addresses;

            model.Address = new AddressModel();
            
            model.Address.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });
            foreach (var c in _countryService.GetAllCountries())
                model.Address.AvailableCountries.Add(new SelectListItem() { Text = c.GetLocalized(x => x.Name), Value = c.Id.ToString() });
            model.Address.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.OtherNonUS"), Value = "0" });

            return View(model);
        }

        [HttpPost]
        public ActionResult AddressAdd(CustomerAddressEditModel model)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Addresses;

            if (ModelState.IsValid)
            {
                var address = model.Address.ToEntity();
                address.CreatedOnUtc = DateTime.UtcNow;
                
                if (address.CountryId == 0)
                    address.CountryId = null;
                if (address.StateProvinceId == 0)
                    address.StateProvinceId = null;
                customer.AddAddress(address);
                _customerService.UpdateCustomer(customer);

                return RedirectToAction("Addresses");
            }
            

            
            
            model.Address.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });
            foreach (var c in _countryService.GetAllCountries())
                model.Address.AvailableCountries.Add(new SelectListItem() { Text = c.GetLocalized(x => x.Name), Value = c.Id.ToString(), Selected = (c.Id == model.Address.CountryId) });
            
            var states = model.Address.CountryId.HasValue ? _stateProvinceService.GetStateProvincesByCountryId(model.Address.CountryId.Value).ToList() : new List<StateProvince>();
            if (states.Count > 0)
            {
                foreach (var s in states)
                    model.Address.AvailableStates.Add(new SelectListItem() { Text = s.GetLocalized(x => x.Name), Value = s.Id.ToString(), Selected = (s.Id == model.Address.StateProvinceId) });
            }
            else
                model.Address.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.OtherNonUS"), Value = "0" });

            return View(model);
        }

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult AddressEdit(int addressId)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            var model = new CustomerAddressEditModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Addresses;

            
            var address = customer.Addresses.Where(a => a.Id == addressId).FirstOrDefault();
            if (address == null)
                
                return RedirectToAction("Addresses");

            model.Address = address.ToModel();
            
            model.Address.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });
            foreach (var c in _countryService.GetAllCountries())
                model.Address.AvailableCountries.Add(new SelectListItem() { Text = c.GetLocalized(x => x.Name), Value = c.Id.ToString(), Selected = (c.Id == address.CountryId) });
            
            var states = address.Country != null ? _stateProvinceService.GetStateProvincesByCountryId(address.Country.Id).ToList() : new List<StateProvince>();
            if (states.Count > 0)
            {
                foreach (var s in states)
                    model.Address.AvailableStates.Add(new SelectListItem() { Text = s.GetLocalized(x => x.Name), Value = s.Id.ToString(), Selected = (s.Id == address.StateProvinceId) });
            }
            else
                model.Address.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.OtherNonUS"), Value = "0" });

            return View(model);
        }

        [HttpPost]
        public ActionResult AddressEdit(CustomerAddressEditModel model, int addressId)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Addresses;

            if (ModelState.IsValid)
            {
                model.NavigationModel = GetCustomerNavigationModel(customer);
                model.NavigationModel.SelectedTab = CustomerNavigationEnum.Addresses;

                
                var address = customer.Addresses.Where(a => a.Id == addressId).FirstOrDefault();
                if (address == null)
                    
                    return RedirectToAction("Addresses");

                address = model.Address.ToEntity(address);
                _addressService.UpdateAddress(address);

                return RedirectToAction("Addresses");
            }

            
            
            model.Address.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });
            foreach (var c in _countryService.GetAllCountries())
                model.Address.AvailableCountries.Add(new SelectListItem() { Text = c.GetLocalized(x => x.Name), Value = c.Id.ToString(), Selected = (c.Id == model.Address.CountryId) });
            
            var states = model.Address.CountryId.HasValue ? _stateProvinceService.GetStateProvincesByCountryId(model.Address.CountryId.Value).ToList() : new List<StateProvince>();
            if (states.Count > 0)
            {
                foreach (var s in states)
                    model.Address.AvailableStates.Add(new SelectListItem() { Text = s.GetLocalized(x => x.Name), Value = s.Id.ToString(), Selected = (s.Id == model.Address.StateProvinceId) });
            }
            else
                model.Address.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Address.OtherNonUS"), Value = "0" });

            return View(model);
        }
           
        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Orders()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;
            var model = PrepareCustomerOrderListModel(customer);
            return View(model);
        }

        [HttpPost, ActionName("Orders")]
        [FormValueRequired(FormValueRequirement.StartsWith, "cancelRecurringPayment")]
        public ActionResult CancelRecurringPayment(FormCollection form)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            
            int recurringPaymentId = 0;
            foreach (var formValue in form.AllKeys)
                if (formValue.StartsWith("cancelRecurringPayment", StringComparison.InvariantCultureIgnoreCase))
                    recurringPaymentId = Convert.ToInt32(formValue.Substring("cancelRecurringPayment".Length));

            var recurringPayment = _orderService.GetRecurringPaymentById(recurringPaymentId);
            if (_orderProcessingService.CanCancelRecurringPayment(customer, recurringPayment))
            {
                var errors = _orderProcessingService.CancelRecurringPayment(recurringPayment);

                var model = PrepareCustomerOrderListModel(customer);
                model.CancelRecurringPaymentErrors = errors;

                return View(model);
            }
            else
            {
                return RedirectToAction("Orders");
            }
        }

        private CustomerOrderListModel PrepareCustomerOrderListModel(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            var model = new CustomerOrderListModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Orders;
            var orders = _orderService.GetOrdersByCustomerId(customer.Id);
            foreach (var order in orders)
            {
                var orderModel = new CustomerOrderListModel.OrderDetailsModel()
                {
                    Id = order.Id,
                    CreatedOn = _dateTimeHelper.ConvertToUserTime(order.CreatedOnUtc, DateTimeKind.Utc),
                    OrderStatus = order.OrderStatus.GetLocalizedEnum(_localizationService, _workContext),
                    IsReturnRequestAllowed = _orderProcessingService.IsReturnRequestAllowed(order)
                };
                var orderTotalInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderTotal, order.CurrencyRate);
                orderModel.OrderTotal = _priceFormatter.FormatPrice(orderTotalInCustomerCurrency, true, order.CustomerCurrencyCode, false);

                model.Orders.Add(orderModel);
            }

            var recurringPayments = _orderService.SearchRecurringPayments(customer.Id, 0, null);
            foreach (var recurringPayment in recurringPayments)
            {
                var recurringPaymentModel = new CustomerOrderListModel.RecurringOrderModel()
                {
                    Id = recurringPayment.Id,
                    StartDate = _dateTimeHelper.ConvertToUserTime(recurringPayment.StartDateUtc, DateTimeKind.Utc).ToString(),
                    CycleInfo =string.Format("{0} {1}", recurringPayment.CycleLength, recurringPayment.CyclePeriod.GetLocalizedEnum(_localizationService,_workContext)),
                    NextPayment = recurringPayment.NextPaymentDate.HasValue ? _dateTimeHelper.ConvertToUserTime(recurringPayment.NextPaymentDate.Value, DateTimeKind.Utc).ToString() : string.Empty,
                    TotalCycles = recurringPayment.TotalCycles,
                    CyclesRemaining = recurringPayment.CyclesRemaining,
                    InitialOrderId = recurringPayment.InitialOrder.Id,
                    CanCancel = _orderProcessingService.CanCancelRecurringPayment(customer, recurringPayment),
                };

                model.RecurringOrders.Add(recurringPaymentModel);
            }

            return model;
        }

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult ReturnRequests()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            var model = new CustomeReturnRequestsModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.ReturnRequests;
            var returnRequests = _orderService.SearchReturnRequests(customer.Id, 0, null);
            foreach (var returnRequest in returnRequests)
            {
                var opv = _orderService.GetOrderProductVariantById(returnRequest.OrderProductVariantId);
                var pv = opv.ProductVariant;

                var itemModel = new CustomeReturnRequestsModel.ReturnRequestModel()
                {
                    Id = returnRequest.Id,
                    ReturnRequestStatus = returnRequest.ReturnRequestStatus.GetLocalizedEnum(_localizationService, _workContext),
                    ProductId = pv.ProductId,
                    ProductSeName = pv.Product.GetSeName(),
                    Quantity = returnRequest.Quantity,
                    ReturnAction = returnRequest.RequestedAction,
                    ReturnReason = returnRequest.ReasonForReturn,
                    Comments = returnRequest.CustomerComments,
                    CreatedOn = _dateTimeHelper.ConvertToUserTime(returnRequest.CreatedOnUtc, DateTimeKind.Utc),
                };
                model.Items.Add(itemModel);

                if (!string.IsNullOrEmpty(pv.GetLocalized(x => x.Name)))
                    itemModel.ProductName = string.Format("{0} ({1})", pv.Product.GetLocalized(x => x.Name), pv.GetLocalized(x => x.Name));
                else
                    itemModel.ProductName = pv.Product.GetLocalized(x => x.Name);
            }

            return View(model);
        }

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult DownloadableProducts()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();
            
            var customer = _workContext.CurrentCustomer;

            var model = new CustomerDownloadableProductsModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.DownloadableProducts;
            var items = _orderService.GetAllOrderProductVariants(null, customer.Id, null, null,
                null, null, null, true);
            foreach (var item in items)
            {
                var itemModel = new CustomerDownloadableProductsModel.DownloadableProductsModel()
                {
                    OrderProductVariantGuid = item.OrderProductVariantGuid,
                    OrderId = item.OrderId,
                    CreatedOn = _dateTimeHelper.ConvertToUserTime(item.Order.CreatedOnUtc, DateTimeKind.Utc),
                    ProductSeName = item.ProductVariant.Product.GetSeName(),
                    ProductAttributes = item.AttributeDescription,
                    ProductId = item.ProductVariant.ProductId
                };
                model.Items.Add(itemModel);

                
                if (!string.IsNullOrEmpty(item.ProductVariant.GetLocalized(x => x.Name)))
                    itemModel.ProductName = string.Format("{0} ({1})", item.ProductVariant.Product.GetLocalized(x => x.Name), item.ProductVariant.GetLocalized(x => x.Name));
                else
                    itemModel.ProductName = item.ProductVariant.Product.GetLocalized(x => x.Name);

                if (_orderProcessingService.IsDownloadAllowed(item))
                    itemModel.DownloadId = item.ProductVariant.DownloadId;

                if (_orderProcessingService.IsLicenseDownloadAllowed(item))
                    itemModel.LicenseId = item.LicenseDownloadId.HasValue ? item.LicenseDownloadId.Value : 0;
            }
            
            return View(model);
        }

        public ActionResult UserAgreement(Guid opvId)
        {
            var opv = _orderService.GetOrderProductVariantByGuid(opvId);
            if (opv == null)
                return RedirectToAction("Index", "Home");


            var productVariant = opv.ProductVariant;
            if (productVariant == null || !productVariant.HasUserAgreement)
                return RedirectToAction("Index", "Home");

            var model = new UserAgreementModel();
            model.UserAgreementText = productVariant.UserAgreementText;
            model.OrderProductVariantGuid = opvId;
            
            return View(model);
        }

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult RewardPoints()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            if (!_rewardPointsSettings.Enabled)
                return RedirectToAction("MyAccount");

            var customer = _workContext.CurrentCustomer;

            var model = new CustomerRewardPointsModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.RewardPoints;
            foreach (var rph in customer.RewardPointsHistory.OrderByDescending(rph => rph.CreatedOnUtc).ThenByDescending(rph => rph.Id))
            {
                model.RewardPoints.Add(new CustomerRewardPointsModel.RewardPointsHistoryModel()
                {
                    Points = rph.Points,
                    PointsBalance = rph.PointsBalance,
                    Message = rph.Message,
                    CreatedOn = _dateTimeHelper.ConvertToUserTime(rph.CreatedOnUtc, DateTimeKind.Utc)
                });
            }
            int rewardPointsBalance = customer.GetRewardPointsBalance();
            decimal rewardPointsAmountBase = _orderTotalCalculationService.ConvertRewardPointsToAmount(rewardPointsBalance);
            decimal rewardPointsAmount =_currencyService.ConvertFromPrimaryStoreCurrency(rewardPointsAmountBase,_workContext.WorkingCurrency);
            model.RewardPointsBalance = string.Format(_localizationService.GetResource("RewardPoints.CurrentBalance"), rewardPointsBalance, _priceFormatter.FormatPrice(rewardPointsAmount, true, false));
            
            return View(model);
        }

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult ChangePassword()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            var model = new ChangePasswordModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.ChangePassword;
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            var customer = _workContext.CurrentCustomer;

            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.ChangePassword;

            if (ModelState.IsValid)
            {
                var changePasswordRequest = new ChangePasswordRequest(customer.Email,
                    true, PasswordFormat.Hashed, model.NewPassword, model.OldPassword);
                var changePasswordResult = _customerService.ChangePassword(changePasswordRequest);
                if (changePasswordResult.Success)
                {
                    model.Result = _localizationService.GetResource("Account.ChangePassword.Success");
                    return View(model);
                }
                else
                {
                    foreach (var error in changePasswordResult.Errors)
                        ModelState.AddModelError(string.Empty, error);
                }
            }


            
            return View(model);
        }

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult Avatar()
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();
            
            if (!_customerSettings.AllowCustomersToUploadAvatars)
                return RedirectToAction("MyAccount");

            var customer = _workContext.CurrentCustomer;

            var model = new CustomerAvatarModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Avatar;
            model.AvatarUrl = _pictureService.GetPictureUrl(
                customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId),
                _mediaSettings.AvatarPictureSize,
                false);
            return View(model);
        }

        [HttpPost, ActionName("Avatar")]
        [FormValueRequired("upload-avatar")]
        public ActionResult UploadAvatar(CustomerAvatarModel model, HttpPostedFileBase uploadedFile)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();
            
            if (!_customerSettings.AllowCustomersToUploadAvatars)
                return RedirectToAction("MyAccount");

            var customer = _workContext.CurrentCustomer;

            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Avatar;


            if (ModelState.IsValid)
            {
                try
                {
                    var customerAvatar = _pictureService.GetPictureById(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId));
                    if ((uploadedFile != null) && (!string.IsNullOrEmpty(uploadedFile.FileName)))
                    {
                        int avatarMaxSize = _customerSettings.AvatarMaximumSizeBytes;
                        if (uploadedFile.ContentLength > avatarMaxSize)
                            throw new FaraException(string.Format("Maximum avatar size is {0} bytes", avatarMaxSize));

                        byte[] customerPictureBinary = uploadedFile.GetPictureBits();
                        if (customerAvatar != null)
                            customerAvatar = _pictureService.UpdatePicture(customerAvatar.Id, customerPictureBinary, uploadedFile.ContentType, null, true);
                        else
                            customerAvatar = _pictureService.InsertPicture(customerPictureBinary, uploadedFile.ContentType, null, true);
                    }

                    int customerAvatarId = 0;
                    if (customerAvatar != null)
                        customerAvatarId = customerAvatar.Id;

                    _customerService.SaveCustomerAttribute<int>(customer, SystemCustomerAttributeNames.AvatarPictureId, customerAvatarId);

                    model.AvatarUrl = _pictureService.GetPictureUrl(
                        customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId),
                        _mediaSettings.AvatarPictureSize,
                        false);
                    return View(model);
                }
                catch (Exception exc)
                {
                    ModelState.AddModelError(string.Empty, exc.Message);
                }
            }


            
            model.AvatarUrl = _pictureService.GetPictureUrl(
                customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId), 
                _mediaSettings.AvatarPictureSize, 
                false);
            return View(model);
        }

        [HttpPost, ActionName("Avatar")]
        [FormValueRequired("remove-avatar")]
        public ActionResult RemoveAvatar(CustomerAvatarModel model, HttpPostedFileBase uploadedFile)
        {
            if (!IsCurrentUserRegistered())
                return new HttpUnauthorizedResult();

            if (!_customerSettings.AllowCustomersToUploadAvatars)
                return RedirectToAction("MyAccount");

            var customer = _workContext.CurrentCustomer;

            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.Avatar;
            
            var customerAvatar = _pictureService.GetPictureById(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId));
            if (customerAvatar != null)
                _pictureService.DeletePicture(customerAvatar);
            _customerService.SaveCustomerAttribute<int>(customer, SystemCustomerAttributeNames.AvatarPictureId, 0);

            return RedirectToAction("Avatar");
        }

        

        

        

        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult PasswordRecovery()
        {
            var model = new PasswordRecoveryModel();
            return View(model);
        }

        [HttpPost, ActionName("PasswordRecovery")]
        [FormValueRequired("send-email")]
        public ActionResult PasswordRecoverySend(PasswordRecoveryModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.GetCustomerByEmail(model.Email);
                if (customer != null)
                {
                    var passwordRecoveryToken = Guid.NewGuid();
                    _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.PasswordRecoveryToken, passwordRecoveryToken.ToString());
                    _workflowMessageService.SendCustomerPasswordRecoveryMessage(customer, _workContext.WorkingLanguage.Id);

                    model.Result = _localizationService.GetResource("Account.PasswordRecovery.EmailHasBeenSent");
                }
                else
                    model.Result = _localizationService.GetResource("Account.PasswordRecovery.EmailNotFound");

                return View(model);
            }

            
            return View(model);
        }


        [FaraHttpsRequirement(SslRequirement.Yes)]
        public ActionResult PasswordRecoveryConfirm(string token, string email)
        {
            var customer = _customerService.GetCustomerByEmail(email);
            if (customer == null )
                return RedirectToAction("Index", "Home");

            var cPrt = customer.GetAttribute<string>(SystemCustomerAttributeNames.PasswordRecoveryToken);
            if (string.IsNullOrEmpty(cPrt))
                return RedirectToAction("Index", "Home");

            if (!cPrt.Equals(token, StringComparison.InvariantCultureIgnoreCase))
                return RedirectToAction("Index", "Home");
            
            var model = new PasswordRecoveryConfirmModel();
            return View(model);
        }

        [HttpPost, ActionName("PasswordRecoveryConfirm")]
        [FormValueRequired("set-password")]
        public ActionResult PasswordRecoveryConfirmPOST(string token, string email, PasswordRecoveryConfirmModel model)
        {
            var customer = _customerService.GetCustomerByEmail(email);
            if (customer == null)
                return RedirectToAction("Index", "Home");

            var cPrt = customer.GetAttribute<string>(SystemCustomerAttributeNames.PasswordRecoveryToken);
            if (string.IsNullOrEmpty(cPrt))
                return RedirectToAction("Index", "Home");

            if (!cPrt.Equals(token, StringComparison.InvariantCultureIgnoreCase))
                return RedirectToAction("Index", "Home");
            
            if (ModelState.IsValid)
            {
                var response = _customerService.ChangePassword(new ChangePasswordRequest(email, 
                    false, PasswordFormat.Hashed, model.NewPassword));
                if (response.Success)
                {
                    _customerService.SaveCustomerAttribute(customer, SystemCustomerAttributeNames.PasswordRecoveryToken, string.Empty);

                    model.SuccessfullyChanged = true;
                    model.Result = _localizationService.GetResource("Account.PasswordRecovery.PasswordHasBeenChanged");
                }
                else
                {
                    model.Result = response.Errors.FirstOrDefault();
                }

                return View(model);
            }

            
            return View(model);
        }

        

        

        public ActionResult ForumSubscriptions(int? page)
        {
            if (!_forumSettings.AllowCustomersToManageSubscriptions)
            {
                return RedirectToAction("MyAccount");
            }

            int pageIndex = 0;
            if (page > 0)
            {
                pageIndex = page.Value - 1;
            }

            var customer = _workContext.CurrentCustomer;

            var pageSize = _forumSettings.ForumSubscriptionsPageSize;

            var list = _forumService.GetAllSubscriptions(customer.Id, 0, 0, pageIndex, pageSize);

            var model = new CustomerForumSubscriptionsModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.ForumSubscriptions;

            foreach (var forumSubscription in list)
            {
                var forumTopicId = forumSubscription.TopicId;
                var forumId = forumSubscription.ForumId;
                bool topicSubscription = false;
                var title = string.Empty;
                var slug = string.Empty;

                if (forumTopicId > 0)
                {
                    topicSubscription = true;
                    var forumTopic = _forumService.GetTopicById(forumTopicId);
                    if (forumTopic != null)
                    {
                        title = forumTopic.Subject;
                        slug = forumTopic.GetSeName();
                    }
                }
                else
                {
                    var forum = _forumService.GetForumById(forumId);
                    if (forum != null)
                    {
                        title = forum.Name;
                        slug = forum.GetSeName();
                    }
                }

                model.ForumSubscriptions.Add(new ForumSubscriptionModel()
                {
                    Id = forumSubscription.Id,
                    ForumTopicId = forumTopicId,
                    ForumId = forumSubscription.ForumId,
                    TopicSubscription = topicSubscription,
                    Title = title,
                    Slug = slug,
                });
            }

            model.PagerModel = new PagerModel()
            {
                PageSize = list.PageSize,
                TotalRecords = list.TotalCount,
                PageIndex = list.PageIndex,
                ShowTotalSummary = false,
                RouteActionName = "CustomerForumSubscriptionsPaged",
                UseRouteLinks = true,
                RouteValues = new ForumSubscriptionsRouteValues { page = pageIndex }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ForumSubscriptions(FormCollection formCollection)
        {
            foreach (var key in formCollection.AllKeys)
            {
                var value = formCollection[key];

                if (value.Equals("on") && key.StartsWith("fs", StringComparison.InvariantCultureIgnoreCase))
                {
                    var id = key.Replace("fs", string.Empty).Trim();
                    int forumSubscriptionId = 0;

                    if (Int32.TryParse(id, out forumSubscriptionId))
                    {
                        var forumSubscription = _forumService.GetSubscriptionById(forumSubscriptionId);
                        if (forumSubscription != null && forumSubscription.CustomerId == _workContext.CurrentCustomer.Id)
                        {
                            _forumService.DeleteSubscription(forumSubscription);
                        }
                    }
                }
            }

            return RedirectToAction("ForumSubscriptions");
        }

        

        

        public ActionResult BackInStockSubscriptions(int? page)
        {
            if (_customerSettings.HideBackInStockSubscriptionsTab)
            {
                return RedirectToAction("MyAccount");
            }

            int pageIndex = 0;
            if (page > 0)
            {
                pageIndex = page.Value - 1;
            }

            var customer = _workContext.CurrentCustomer;
            var pageSize = 10;
            var list = _backInStockSubscriptionService.GetAllSubscriptionsByCustomerId(customer.Id, pageIndex, pageSize);

            var model = new CustomerBackInStockSubscriptionsModel();
            model.NavigationModel = GetCustomerNavigationModel(customer);
            model.NavigationModel.SelectedTab = CustomerNavigationEnum.BackInStockSubscriptions;

            foreach (var subscription in list)
            {
                var productVariant = subscription.ProductVariant;

                if (productVariant != null)
                {
                    var subscriptionModel = new BackInStockSubscriptionModel()
                    {
                        Id = subscription.Id,
                        ProductId = productVariant.Product.Id,
                        SeName = productVariant.Product.GetSeName(),
                    };
                    
                    if (!string.IsNullOrEmpty(productVariant.GetLocalized(x => x.Name)))
                        subscriptionModel.ProductName = string.Format("{0} ({1})",
                                                                      productVariant.Product.GetLocalized(x => x.Name),
                                                                      productVariant.GetLocalized(x => x.Name));
                    else
                        subscriptionModel.ProductName = productVariant.Product.GetLocalized(x => x.Name);

                    model.Subscriptions.Add(subscriptionModel);
                }
            }

            model.PagerModel = new PagerModel()
            {
                PageSize = list.PageSize,
                TotalRecords = list.TotalCount,
                PageIndex = list.PageIndex,
                ShowTotalSummary = false,
                RouteActionName = "CustomerBackInStockSubscriptionsPaged",
                UseRouteLinks = true,
                RouteValues = new BackInStockSubscriptionsRouteValues { page = pageIndex }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult BackInStockSubscriptions(FormCollection formCollection)
        {
            foreach (var key in formCollection.AllKeys)
            {
                var value = formCollection[key];

                if (value.Equals("on") && key.StartsWith("biss", StringComparison.InvariantCultureIgnoreCase))
                {
                    var id = key.Replace("biss", string.Empty).Trim();
                    int subscriptionId = 0;

                    if (Int32.TryParse(id, out subscriptionId))
                    {
                        var subscription = _backInStockSubscriptionService.GetSubscriptionById(subscriptionId);
                        if (subscription != null && subscription.CustomerId == _workContext.CurrentCustomer.Id)
                        {
                            _backInStockSubscriptionService.DeleteSubscription(subscription);
                        }
                    }
                }
            }

            return RedirectToAction("BackInStockSubscriptions");
        }

        
    }
}
