namespace FaraMedia.Services.Utilities {
    using System.Collections.Generic;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Services.Helpers;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Systematic;

    public class MessageTokenProvider : IMessageTokenProvider {
        private readonly IDbService<EmailAccount, EmailAccountQuery> _emailAccountService;
        private readonly IDbService<ResourceValue, ResourceValueQuery> _resourceValueService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IWebHelper _webHelper;
        private readonly SystemSettings _systemSettings;

        public MessageTokenProvider(
            IDbService<EmailAccount, EmailAccountQuery> emailAccountService,
            IDbService<ResourceValue, ResourceValueQuery> resourceValueService,
            IDateTimeHelper dateTimeHelper,
            IWebHelper webHelper,
            SystemSettings systemSettings) {
            _emailAccountService = emailAccountService;
            _resourceValueService = resourceValueService;
            _dateTimeHelper = dateTimeHelper;
            _webHelper = webHelper;
            _systemSettings = systemSettings;
        }

        public virtual void AddOrderTokens(IList<Token> tokens, Order order) {
            tokens.Add(new Token("Order.OrderNumber", order.Id.ToString()));
        }

        //protected virtual string ProductListToHtmlTable(Order order, int languageId) {
        //    string result;

        //    var language = _languageService.GetLanguageById(languageId);

        //    var stringBuilder = new StringBuilder();
        //    stringBuilder.AppendLine("<table border=\"0\" style=\"width:100%;\">");

        //    stringBuilder.AppendLine(string.Format("<tr style=\"background-color:{0};text-align:center;\">",
        //                                           _templatesSettings.Color1));
        //    stringBuilder.AppendLine(string.Format("<th>{0}</th>",
        //                                           _localizationService.GetResourceValue(
        //                                               "Messages.Order.Product(s).Name", languageId)));
        //    stringBuilder.AppendLine(string.Format("<th>{0}</th>",
        //                                           _localizationService.GetResourceValue(
        //                                               "Messages.Order.Product(s).Price", languageId)));
        //    stringBuilder.AppendLine(string.Format("<th>{0}</th>",
        //                                           _localizationService.GetResourceValue(
        //                                               "Messages.Order.Product(s).Quantity", languageId)));
        //    stringBuilder.AppendLine(string.Format("<th>{0}</th>",
        //                                           _localizationService.GetResourceValue(
        //                                               "Messages.Order.Product(s).Total", languageId)));
        //    stringBuilder.AppendLine("</tr>");

        //    var orderLines = order.OrderLines.ToList();
        //    for (var i = 0; i <= orderLines.Count - 1; i++) {
        //        var orderLine = orderLines[i];

        //        stringBuilder.AppendLine(string.Format("<tr style=\"background-color: {0};text-align: center;\">",
        //                                               _templatesSettings.Color2));

        //        string productName;

        //        if (!string.IsNullOrEmpty(orderLine.ProductVariant.GetLocalized(x => x.Name, languageId))) {
        //            productName = string.Format("{0} ({1})",
        //                                        orderLine.ProductVariant.Product.GetLocalized(x => x.Name, languageId),
        //                                        orderLine.ProductVariant.GetLocalized(x => x.Name, languageId));
        //        } else
        //            productName = orderLine.ProductVariant.Product.GetLocalized(x => x.Name, languageId);

        //        stringBuilder.AppendLine("<td style=\"padding: 0.6em 0.4em;text-align: left;\">" +
        //                                 HttpUtility.HtmlEncode(productName));

        //        var orderProcessingService = EngineContext.Current.Resolve<IOrderProcessingService>();
        //        if (orderProcessingService.IsDownloadAllowed(orderLine)) {
        //            var downloadUrl = string.Format("{0}download/getdownload?opvId={1}",
        //                                            _webHelper.GetAppLocation(false),
        //                                            orderLine.OrderProductVariantGuid);
        //            var downloadLink = string.Format("<a class=\"link\" href=\"{0}\">{1}</a>",
        //                                             downloadUrl,
        //                                             _localizationService.GetResourceValue(
        //                                                 "Messages.Order.Products(s).Download", languageId));
        //            stringBuilder.AppendLine("&nbsp;&nbsp;(");
        //            stringBuilder.AppendLine(downloadLink);
        //            stringBuilder.AppendLine(")");
        //        }

        //        if (!string.IsNullOrEmpty(orderLine.AttributeDescription)) {
        //            stringBuilder.AppendLine("<br />");
        //            stringBuilder.AppendLine(orderLine.AttributeDescription);
        //        }

        //        if (_catalogSettings.ShowProductSku) {
        //            if (!string.IsNullOrEmpty(orderLine.ProductVariant.Sku)) {
        //                stringBuilder.AppendLine("<br />");
        //                var sku =
        //                    string.Format(
        //                        _localizationService.GetResourceValue("Messages.Order.Product(s).SKU", languageId),
        //                        HttpUtility.HtmlEncode(orderLine.ProductVariant.Sku));
        //                stringBuilder.AppendLine(sku);
        //            }
        //        }
        //        stringBuilder.AppendLine("</td>");

        //        var unitPriceStr = string.Empty;
        //        switch (order.UserTaxDisplayType) {
        //            case TaxDisplayType.ExcludingTax: {
        //                var opvUnitPriceExclTaxInUserCurrency =
        //                    _currencyService.ConvertCurrency(orderLine.UnitPriceExclTax, order.CurrencyRate);
        //                unitPriceStr = _priceFormatter.FormatPrice(opvUnitPriceExclTaxInUserCurrency,
        //                                                           true,
        //                                                           order.UserCurrencyCode,
        //                                                           language,
        //                                                           false);
        //            }
        //                break;
        //            case TaxDisplayType.IncludingTax: {
        //                var opvUnitPriceInclTaxInUserCurrency =
        //                    _currencyService.ConvertCurrency(orderLine.UnitPriceInclTax, order.CurrencyRate);
        //                unitPriceStr = _priceFormatter.FormatPrice(opvUnitPriceInclTaxInUserCurrency,
        //                                                           true,
        //                                                           order.UserCurrencyCode,
        //                                                           language,
        //                                                           true);
        //            }
        //                break;
        //        }
        //        stringBuilder.AppendLine(string.Format(
        //            "<td style=\"padding: 0.6em 0.4em;text-align: right;\">{0}</td>", unitPriceStr));

        //        stringBuilder.AppendLine(string.Format(
        //            "<td style=\"padding: 0.6em 0.4em;text-align: center;\">{0}</td>", orderLine.Quantity));

        //        var priceStr = string.Empty;
        //        switch (order.UserTaxDisplayType) {
        //            case TaxDisplayType.ExcludingTax: {
        //                var opvPriceExclTaxInUserCurrency = _currencyService.ConvertCurrency(orderLine.PriceExclTax,
        //                                                                                     order.CurrencyRate);
        //                priceStr = _priceFormatter.FormatPrice(opvPriceExclTaxInUserCurrency,
        //                                                       true,
        //                                                       order.UserCurrencyCode,
        //                                                       language,
        //                                                       false);
        //            }
        //                break;
        //            case TaxDisplayType.IncludingTax: {
        //                var opvPriceInclTaxInUserCurrency = _currencyService.ConvertCurrency(orderLine.PriceInclTax,
        //                                                                                     order.CurrencyRate);
        //                priceStr = _priceFormatter.FormatPrice(opvPriceInclTaxInUserCurrency,
        //                                                       true,
        //                                                       order.UserCurrencyCode,
        //                                                       language,
        //                                                       true);
        //            }
        //                break;
        //        }
        //        stringBuilder.AppendLine(string.Format(
        //            "<td style=\"padding: 0.6em 0.4em;text-align: right;\">{0}</td>", priceStr));

        //        stringBuilder.AppendLine("</tr>");
        //    }

        //    if (!string.IsNullOrEmpty(order.CheckoutAttributeDescription)) {
        //        stringBuilder.AppendLine(
        //            "<tr><td style=\"text-align:right;\" colspan=\"1\">&nbsp;</td><td colspan=\"3\" style=\"text-align:right\">");
        //        stringBuilder.AppendLine(order.CheckoutAttributeDescription);
        //        stringBuilder.AppendLine("</td></tr>");
        //    }

        //    var cusSubTotal = string.Empty;
        //    var dislaySubTotalDiscount = false;
        //    var cusSubTotalDiscount = string.Empty;
        //    var cusShipTotal = string.Empty;
        //    var cusPaymentMethodAdditionalFee = string.Empty;
        //    var taxRates = new SortedDictionary<decimal, decimal>();
        //    var cusTaxTotal = string.Empty;
        //    var cusDiscount = string.Empty;
        //    var cusTotal = string.Empty;

        //    switch (order.UserTaxDisplayType) {
        //        case TaxDisplayType.ExcludingTax: {
        //            var orderSubtotalExclTaxInUserCurrency = _currencyService.ConvertCurrency(
        //                order.OrderSubtotalExclTax, order.CurrencyRate);
        //            cusSubTotal = _priceFormatter.FormatPrice(orderSubtotalExclTaxInUserCurrency,
        //                                                      true,
        //                                                      order.UserCurrencyCode,
        //                                                      language,
        //                                                      false);

        //            var orderSubTotalDiscountExclTaxInUserCurrency =
        //                _currencyService.ConvertCurrency(order.OrderSubTotalDiscountExclTax, order.CurrencyRate);
        //            if (orderSubTotalDiscountExclTaxInUserCurrency > decimal.Zero) {
        //                cusSubTotalDiscount = _priceFormatter.FormatPrice(-orderSubTotalDiscountExclTaxInUserCurrency,
        //                                                                  true,
        //                                                                  order.UserCurrencyCode,
        //                                                                  language,
        //                                                                  false);
        //                dislaySubTotalDiscount = true;
        //            }

        //            var orderShippingExclTaxInUserCurrency = _currencyService.ConvertCurrency(
        //                order.OrderShippingExclTax, order.CurrencyRate);
        //            cusShipTotal = _priceFormatter.FormatShippingPrice(orderShippingExclTaxInUserCurrency,
        //                                                               true,
        //                                                               order.UserCurrencyCode,
        //                                                               language,
        //                                                               false);

        //            var paymentMethodAdditionalFeeExclTaxInUserCurrency =
        //                _currencyService.ConvertCurrency(order.PaymentMethodAdditionalFeeExclTax, order.CurrencyRate);
        //            cusPaymentMethodAdditionalFee =
        //                _priceFormatter.FormatPaymentMethodAdditionalFee(
        //                    paymentMethodAdditionalFeeExclTaxInUserCurrency,
        //                    true,
        //                    order.UserCurrencyCode,
        //                    language,
        //                    false);
        //        }
        //            break;
        //        case TaxDisplayType.IncludingTax: {
        //            var orderSubtotalInclTaxInUserCurrency = _currencyService.ConvertCurrency(
        //                order.OrderSubtotalInclTax, order.CurrencyRate);
        //            cusSubTotal = _priceFormatter.FormatPrice(orderSubtotalInclTaxInUserCurrency,
        //                                                      true,
        //                                                      order.UserCurrencyCode,
        //                                                      language,
        //                                                      true);

        //            var orderSubTotalDiscountInclTaxInUserCurrency =
        //                _currencyService.ConvertCurrency(order.OrderSubTotalDiscountInclTax, order.CurrencyRate);
        //            if (orderSubTotalDiscountInclTaxInUserCurrency > decimal.Zero) {
        //                cusSubTotalDiscount = _priceFormatter.FormatPrice(-orderSubTotalDiscountInclTaxInUserCurrency,
        //                                                                  true,
        //                                                                  order.UserCurrencyCode,
        //                                                                  language,
        //                                                                  true);
        //                dislaySubTotalDiscount = true;
        //            }

        //            var orderShippingInclTaxInUserCurrency = _currencyService.ConvertCurrency(
        //                order.OrderShippingInclTax, order.CurrencyRate);
        //            cusShipTotal = _priceFormatter.FormatShippingPrice(orderShippingInclTaxInUserCurrency,
        //                                                               true,
        //                                                               order.UserCurrencyCode,
        //                                                               language,
        //                                                               true);

        //            var paymentMethodAdditionalFeeInclTaxInUserCurrency =
        //                _currencyService.ConvertCurrency(order.PaymentMethodAdditionalFeeInclTax, order.CurrencyRate);
        //            cusPaymentMethodAdditionalFee =
        //                _priceFormatter.FormatPaymentMethodAdditionalFee(
        //                    paymentMethodAdditionalFeeInclTaxInUserCurrency,
        //                    true,
        //                    order.UserCurrencyCode,
        //                    language,
        //                    true);
        //        }
        //            break;
        //    }

        //    var dislayShipping = order.ShippingStatus != ShippingStatus.ShippingNotRequired;

        //    var displayPaymentMethodFee = true;
        //    if (order.PaymentMethodAdditionalFeeExclTax == decimal.Zero)
        //        displayPaymentMethodFee = false;

        //    var displayTax = true;
        //    var displayTaxRates = true;
        //    if (_taxSettings.HideTaxInOrderSummary && order.UserTaxDisplayType == TaxDisplayType.IncludingTax) {
        //        displayTax = false;
        //        displayTaxRates = false;
        //    } else {
        //        if (order.OrderTax == 0 && _taxSettings.HideZeroTax) {
        //            displayTax = false;
        //            displayTaxRates = false;
        //        } else {
        //            taxRates = new SortedDictionary<decimal, decimal>();
        //            foreach (var tr in order.TaxRatesDictionary)
        //                taxRates.Add(tr.Key, _currencyService.ConvertCurrency(tr.Value, order.CurrencyRate));

        //            displayTaxRates = _taxSettings.DisplayTaxRates && taxRates.Count > 0;
        //            displayTax = !displayTaxRates;

        //            var orderTaxInUserCurrency = _currencyService.ConvertCurrency(order.OrderTax, order.CurrencyRate);

        //            var taxStr = _priceFormatter.FormatPrice(orderTaxInUserCurrency, true, order.UserCurrencyCode, false);
        //            cusTaxTotal = taxStr;
        //        }
        //    }

        //    var dislayDiscount = false;
        //    if (order.OrderDiscount > decimal.Zero) {
        //        var orderDiscountInUserCurrency = _currencyService.ConvertCurrency(order.OrderDiscount,
        //                                                                           order.CurrencyRate);
        //        cusDiscount = _priceFormatter.FormatPrice(-orderDiscountInUserCurrency,
        //                                                  true,
        //                                                  order.UserCurrencyCode,
        //                                                  false);
        //        dislayDiscount = true;
        //    }

        //    var orderTotalInUserCurrency = _currencyService.ConvertCurrency(order.OrderTotal, order.CurrencyRate);

        //    cusTotal = _priceFormatter.FormatPrice(orderTotalInUserCurrency, true, order.UserCurrencyCode, false);

        //    stringBuilder.AppendLine(
        //        string.Format(
        //            "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //            _templatesSettings.Color3,
        //            _localizationService.GetResourceValue("Messages.Order.SubTotal", languageId),
        //            cusSubTotal));

        //    if (dislaySubTotalDiscount) {
        //        stringBuilder.AppendLine(
        //            string.Format(
        //                "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                _templatesSettings.Color3,
        //                _localizationService.GetResourceValue("Messages.Order.SubTotalDiscount", languageId),
        //                cusSubTotalDiscount));
        //    }

        //    if (dislayShipping) {
        //        stringBuilder.AppendLine(
        //            string.Format(
        //                "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                _templatesSettings.Color3,
        //                _localizationService.GetResourceValue("Messages.Order.Shipping", languageId),
        //                cusShipTotal));
        //    }

        //    if (displayPaymentMethodFee) {
        //        var paymentMethodFeeTitle =
        //            _localizationService.GetResourceValue("Messages.Order.PaymentMethodAdditionalFee", languageId);
        //        stringBuilder.AppendLine(
        //            string.Format(
        //                "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                _templatesSettings.Color3,
        //                paymentMethodFeeTitle,
        //                cusPaymentMethodAdditionalFee));
        //    }

        //    if (displayTax) {
        //        stringBuilder.AppendLine(
        //            string.Format(
        //                "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                _templatesSettings.Color3,
        //                _localizationService.GetResourceValue("Messages.Order.Tax", languageId),
        //                cusTaxTotal));
        //    }
        //    if (displayTaxRates) {
        //        foreach (var item in taxRates) {
        //            var taxRate = string.Format(_localizationService.GetResourceValue("Messages.Order.TaxRateLine"),
        //                                        _priceFormatter.FormatTaxRate(item.Key));

        //            var taxValue = _priceFormatter.FormatPrice(item.Value, true, order.UserCurrencyCode, false);
        //            stringBuilder.AppendLine(
        //                string.Format(
        //                    "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                    _templatesSettings.Color3,
        //                    taxRate,
        //                    taxValue));
        //        }
        //    }

        //    if (dislayDiscount) {
        //        stringBuilder.AppendLine(
        //            string.Format(
        //                "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                _templatesSettings.Color3,
        //                _localizationService.GetResourceValue("Messages.Order.TotalDiscount", languageId),
        //                cusDiscount));
        //    }

        //    var gcuhC = order.GiftCardUsageHistory;
        //    foreach (var gcuh in gcuhC) {
        //        var giftCardText =
        //            string.Format(_localizationService.GetResourceValue("Messages.Order.GiftCardInfo", languageId),
        //                          HttpUtility.HtmlEncode(gcuh.GiftCard.GiftCardCouponCode));
        //        var giftCardAmount =
        //            _priceFormatter.FormatPrice(
        //                -(_currencyService.ConvertCurrency(gcuh.UsedValue, order.CurrencyRate)),
        //                true,
        //                order.UserCurrencyCode,
        //                false);
        //        stringBuilder.AppendLine(
        //            string.Format(
        //                "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                _templatesSettings.Color3,
        //                giftCardText,
        //                giftCardAmount));
        //    }

        //    if (order.RedeemedRewardPointsEntry != null) {
        //        var rpTitle =
        //            string.Format(_localizationService.GetResourceValue("Messages.Order.RewardPoints", languageId),
        //                          -order.RedeemedRewardPointsEntry.Points);
        //        var rpAmount =
        //            _priceFormatter.FormatPrice(
        //                -(_currencyService.ConvertCurrency(order.RedeemedRewardPointsEntry.UsedAmount,
        //                                                   order.CurrencyRate)),
        //                true,
        //                order.UserCurrencyCode,
        //                false);
        //        stringBuilder.AppendLine(
        //            string.Format(
        //                "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //                _templatesSettings.Color3,
        //                rpTitle,
        //                rpAmount));
        //    }

        //    stringBuilder.AppendLine(
        //        string.Format(
        //            "<tr style=\"text-align:right;\"><td>&nbsp;</td><td colspan=\"2\" style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{1}</strong></td> <td style=\"background-color: {0};padding:0.6em 0.4 em;\"><strong>{2}</strong></td></tr>",
        //            _templatesSettings.Color3,
        //            _localizationService.GetResourceValue("Messages.Order.OrderTotal", languageId),
        //            cusTotal));

        //    stringBuilder.AppendLine("</table>");
        //    result = stringBuilder.ToString();
        //    return result;
        //}

        //public virtual void AddStoreTokens(IList<Token> tokens) {
        //    tokens.Add(new Token("Store.Name", _applicationSettings.StoreName));
        //    tokens.Add(new Token("Store.URL", _applicationSettings.StoreUrl, true));
        //    var defaultEmailAccount =
        //        _emailAccountService.GetEmailAccountById(_emailAccountSettings.DefaultEmailAccountId);
        //    if (defaultEmailAccount == null)
        //        defaultEmailAccount = _emailAccountService.GetAllEmailAccounts().FirstOrDefault();
        //    tokens.Add(new Token("Store.Email", defaultEmailAccount.Email));
        //}

        //public virtual void AddUserTokens(IList<Token> tokens, User user) {
        //    tokens.Add(new Token("User.Email", user.Email));
        //    tokens.Add(new Token("User.UserName", user.UserName));
        //    tokens.Add(new Token("User.FullName", user.Name.ToString()));

        //    var passwordRecoveryUrl = string.Format("{0}passwordrecovery/confirm?token={1}&email={2}",
        //                                            _webHelper.GetAppLocation(false),
        //                                            user.GetAttribute<string>(UserAttributeNames.PasswordRecoveryToken),
        //                                            user.Email);

        //    var accountActivationUrl = string.Format("{0}user/activation?token={1}&email={2}",
        //                                             _webHelper.GetAppLocation(false),
        //                                             user.GetAttribute<string>(UserAttributeNames.AccountActivationToken),
        //                                             user.Email);

        //    tokens.Add(new Token("User.PasswordRecoveryURL", passwordRecoveryUrl, true));
        //    tokens.Add(new Token("User.AccountActivationURL", accountActivationUrl, true));
        //}

        //public virtual void AddNewsletterSubscriptionTokens(IList<Token> tokens,
        //                                                    NewsletterSubscription newsletterSubscription) {
        //    tokens.Add(new Token("NewsLetterSubscription.Email", newsletterSubscription.Email));

        //    const string urlFormat = "{0}newsletter/subscriptionactivation/{1}/{2}";

        //    var activationUrl = string.Format(urlFormat,
        //                                      _webHelper.GetAppLocation(false),
        //                                      newsletterSubscription.Guid,
        //                                      "true");
        //    tokens.Add(new Token("NewsletterSubscription.ActivationUrl", activationUrl, true));

        //    var deActivationUrl = string.Format(urlFormat,
        //                                        _webHelper.GetAppLocation(false),
        //                                        newsletterSubscription.Guid,
        //                                        "false");
        //    tokens.Add(new Token("NewsletterSubscription.DeactivationUrl", deActivationUrl, true));
        //}

        //public virtual string[] GetListOfAllowedTokens() {
        //    var allowedTokens = new List<string> {
        //                                             "%Store.Name%",
        //                                             "%Store.URL%",
        //                                             "%Store.Email%",
        //                                             "%Order.OrderNumber%",
        //                                             "%Order.UserFullName%",
        //                                             "%Order.UserEmail%",
        //                                             "%Order.BillingFirstName%",
        //                                             "%Order.BillingLastName%",
        //                                             "%Order.BillingPhoneNumber%",
        //                                             "%Order.BillingEmail%",
        //                                             "%Order.BillingFaxNumber%",
        //                                             "%Order.BillingCompany%",
        //                                             "%Order.BillingAddress2%",
        //                                             "%Order.BillingCity%",
        //                                             "%Order.BillingStateProvince%",
        //                                             "%Order.BillingZipPostalCode%",
        //                                             "%Order.BillingCountry%",
        //                                             "%Order.ShippingMethod%",
        //                                             "%Order.ShippingFirstName%",
        //                                             "%Order.ShippingLastName%",
        //                                             "%Order.ShippingPhoneNumber%",
        //                                             "%Order.ShippingEmail%",
        //                                             "%Order.ShippingFaxNumber%",
        //                                             "%Order.ShippingCompany%",
        //                                             "%Order.ShippingAddress1%",
        //                                             "%Order.ShippingAddress2%",
        //                                             "%Order.ShippingCity%",
        //                                             "%Order.ShippingStateProvince%",
        //                                             "%Order.ShippingZipPostalCode%",
        //                                             "%Order.ShippingCountry%",
        //                                             "%Order.TrackingNumber%",
        //                                             "%Order.VatNumber%",
        //                                             "%Order.Product(s)%",
        //                                             "%Order.CreatedOn%",
        //                                             "%Order.OrderURLForUser%",
        //                                             "%ReturnRequest.ID%",
        //                                             "%ReturnRequest.Product.Quantity%",
        //                                             "%ReturnRequest.Product.Name%",
        //                                             "%ReturnRequest.Reason%",
        //                                             "%ReturnRequest.RequestedAction%",
        //                                             "%ReturnRequest.UserComment%",
        //                                             "%GiftCard.SenderName%",
        //                                             "%GiftCard.SenderEmail%",
        //                                             "%GiftCard.RecipientName%",
        //                                             "%GiftCard.RecipientEmail%",
        //                                             "%GiftCard.Amount%",
        //                                             "%GiftCard.CouponCode%",
        //                                             "%GiftCard.Message%",
        //                                             "%User.Email%",
        //                                             "%User.UserName%",
        //                                             "%User.FullName%",
        //                                             "%User.VatNumber%",
        //                                             "%User.VatNumberStatus%",
        //                                             "%User.PasswordRecoveryURL%",
        //                                             "%User.AccountActivationURL%",
        //                                             "%Wishlist.URLForUser%",
        //                                             "NewsLetterSubscription.Email%",
        //                                             "%NewsLetterSubscription.ActivationUrl%",
        //                                             "%NewsLetterSubscription.DeactivationUrl%",
        //                                             "%ProductReview.ProductName%",
        //                                             "%BlogComment.PostTitle%",
        //                                             "%Comment.ContentManagementTitle%",
        //                                             "%Product.Name%",
        //                                             "%Product.ShortDescription%",
        //                                             "%Product.ProductURLForUser%",
        //                                             "%ProductVariant.ID%",
        //                                             "%ProductVariant.FullProductName%",
        //                                             "%ProductVariant.StockQuantity%",
        //                                             "%Forums.TopicURL%",
        //                                             "%Forums.TopicName%",
        //                                             "%Forums.PostUser%",
        //                                             "%Forums.PostBody%",
        //                                             "%Forums.ForumURL%",
        //                                             "%Forums.ForumName%",
        //                                             "%PrivateMessage.Subject%",
        //                                             "%PrivateMessage.Text%",
        //                                             "%BackInStockSubscription.ProductName%",
        //                                         };
        //    return allowedTokens.ToArray();
        //}
    }
}