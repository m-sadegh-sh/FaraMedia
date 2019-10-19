namespace FaraMedia.Services.Utilities {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FaraMedia.Core.Domain;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Systematic;
    using FaraMedia.Services.Systematic;

    public class WorkflowMessageService : IWorkflowMessageService {
        private readonly IDbService<EmailAccount, EmailAccountQuery> _emailAccountService;
        private readonly IDbService<MessageTemplate, MessageTemplateQuery> _messageTemplateService;
        private readonly IDbService<QueuedEmail, QueuedEmailQuery> _queuedEmailService;
        private readonly IMessageTokenProvider _messageTokenProvider;
        private readonly ITokenizer _tokenizer;
        private readonly SystemSettings _systemSettings;

        public WorkflowMessageService(IDbService<EmailAccount, EmailAccountQuery> emailAccountService,
                                      IDbService<MessageTemplate, MessageTemplateQuery> messageTemplateService,
                                      IDbService<QueuedEmail, QueuedEmailQuery> queuedEmailService,
                                      IMessageTokenProvider messageTokenProvider,
                                      ITokenizer tokenizer,
                                      SystemSettings systemSettings) {
            _emailAccountService = emailAccountService;
            _messageTemplateService = messageTemplateService;
            _queuedEmailService = queuedEmailService;
            _messageTokenProvider = messageTokenProvider;
            _tokenizer = tokenizer;
            _systemSettings = systemSettings;
        }

        public virtual long SendUserRegisteredNotificationMessage(User user) {
            if (user == null)
                throw new ArgumentNullException("user");

            var messageTemplate = GetMessageTemplate("NewUser.Notification");

            if (messageTemplate == null)
                return 0;

            var userTokens = GenerateTokens(user);

            var emailAccount = GetNotificationEmailAccount();
            var toEmail = emailAccount.Email;
            var toName = emailAccount.DisplayName;

            return SendNotification(messageTemplate, emailAccount, userTokens, toEmail, toName);
        }

        private long SendNotification(MessageTemplate messageTemplate,
                                      EmailAccount emailAccount,
                                      IList<Token> tokens,
                                      string email,
                                      string toName) {
            var subjectReplaced = _tokenizer.Replace(messageTemplate.Subject, tokens, false);
            var bodyReplaced = _tokenizer.Replace(messageTemplate.Body, tokens, true);

            var queuedEmail = new QueuedEmail {
                From = emailAccount.Email,
                FromName = emailAccount.DisplayName,
                To = email,
                ToName = toName,
                Cc = string.Empty,
                Bcc = messageTemplate.BccEmailAddresses,
                Subject = subjectReplaced,
                Body = bodyReplaced,
                SendPriority = Priority.Medium,
                EmailAccountId = emailAccount.Id
            };

            _queuedEmailService.Save(queuedEmail);

            return queuedEmail.Id;
        }

        private IList<Token> GenerateTokens(User user) {
            var tokens = new List<Token>();

            //_messageTokenProvider.AddStoreTokens(tokens);
            //_messageTokenProvider.AddUserTokens(tokens, user);

            return tokens;
        }

        //private IList<Token> GenerateTokens(User user, Product product) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddUserTokens(tokens, user);
        //    _messageTokenProvider.AddProductTokens(tokens, product);

        //    return tokens;
        //}

        //private IEnumerable<Token> GenerateTokens(Order order, int languageId) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddOrderTokens(tokens, order, languageId);

        //    return tokens;
        //}

        //private IEnumerable<Token> GenerateTokens(ReturnRequest returnRequest, OrderProductVariant opv) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddUserTokens(tokens, returnRequest.User);
        //    _messageTokenProvider.AddReturnRequestTokens(tokens, returnRequest, opv);

        //    return tokens;
        //}

        //private IEnumerable<Token> GenerateTokens(GiftCard giftCard) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddGiftCardTokens(tokens, giftCard);

        //    return tokens;
        //}

        //private IEnumerable<Token> GenerateTokens(NewsletterSubscription subscription) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddNewsletterSubscriptionTokens(tokens, subscription);

        //    return tokens;
        //}

        //private IEnumerable<Token> GenerateTokens(ProductReview productReview) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddProductReviewTokens(tokens, productReview);

        //    return tokens;
        //}

        //private IEnumerable<Token> GenerateTokens(PostComment blogComment) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddBlogCommentTokens(tokens, blogComment);

        //    return tokens;
        //}

        //private IEnumerable<Token> GenerateTokens(Comment comment) {
        //    var tokens = new List<Token>();

        //    _messageTokenProvider.AddStoreTokens(tokens);
        //    _messageTokenProvider.AddCommentTokens(tokens, comment);

        //    return tokens;
        //}

        private MessageTemplate GetMessageTemplate(string name) {
            var messageTemplate = _messageTemplateService.GetBySystemName(name);

            return messageTemplate;
        }

        private EmailAccount GetNotificationEmailAccount() {
            var emailAccount = _emailAccountService.GetById(_systemSettings.DefaultEmailAccountId);

            if (emailAccount == null)
                emailAccount = _emailAccountService.GetAll().FirstOrDefault();

            return emailAccount;
        }

        //public virtual int SendUserWelcomeMessage(User user, int languageId) {
        //    Argument.ShouldNotBeNull(() => user);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("User.WelcomeMessage", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var userTokens = GenerateTokens(user);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = user.Email;
        //    var toName = user.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  userTokens, toEmail, toName);
        //}

        //public virtual int SendUserEmailValidationMessage(User user, int languageId) {
        //    Argument.ShouldNotBeNull(() => user);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("User.EmailValidationMessage", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var userTokens = GenerateTokens(user);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = user.Email;
        //    var toName = user.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  userTokens, toEmail, toName);
        //}

        //public virtual int SendUserPasswordRecoveryMessage(User user, int languageId) {
        //    Argument.ShouldNotBeNull(() => user);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("User.PasswordRecovery", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var userTokens = GenerateTokens(user);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = user.Email;
        //    var toName = user.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  userTokens, toEmail, toName);
        //}

        //public virtual int SendOrderPlacedStoreOwnerNotification(Order order, int languageId) {
        //    Argument.ShouldNotBeNull(() => order);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("OrderPlaced.StoreOwnerNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(order, languageId);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = emailAccount.Email;
        //    var toName = emailAccount.DisplayName;

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendOrderPlacedUserNotification(Order order, int languageId) {
        //    Argument.ShouldNotBeNull(() => order);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("OrderPlaced.UserNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(order, languageId);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = order.BillingAddress.Email;
        //    var toName = string.Format("{0} {1}", order.BillingAddress.FirstName, order.BillingAddress.LastName);
        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendOrderShippedUserNotification(Order order, int languageId) {
        //    Argument.ShouldNotBeNull(() => order);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("OrderShipped.UserNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(order, languageId);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = order.BillingAddress.Email;
        //    var toName = string.Format("{0} {1}", order.BillingAddress.FirstName, order.BillingAddress.LastName);

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendOrderDeliveredUserNotification(Order order, int languageId) {
        //    Argument.ShouldNotBeNull(() => order);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("OrderDelivered.UserNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(order, languageId);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = order.BillingAddress.Email;
        //    var toName = string.Format("{0} {1}", order.BillingAddress.FirstName, order.BillingAddress.LastName);

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendOrderCompletedUserNotification(Order order, int languageId) {
        //    Argument.ShouldNotBeNull(() => order);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("OrderCompleted.UserNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(order, languageId);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = order.BillingAddress.Email;
        //    var toName = string.Format("{0} {1}", order.BillingAddress.FirstName, order.BillingAddress.LastName);

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendOrderCancelledUserNotification(Order order, int languageId) {
        //    Argument.ShouldNotBeNull(() => order);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("OrderCancelled.UserNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(order, languageId);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = order.BillingAddress.Email;
        //    var toName = string.Format("{0} {1}", order.BillingAddress.FirstName, order.BillingAddress.LastName);

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendNewsLetterSubscriptionActivationMessage(NewsLetterSubscription subscription,
        //                                                               int languageId) {
        //    Argument.ShouldNotBeNull(() => subscription);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("NewsLetterSubscription.ActivationMessage",
        //                                                            languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(subscription);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = subscription.Email;
        //    var toName = string.Empty;

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendNewsLetterSubscriptionDeactivationMessage(NewsLetterSubscription subscription,
        //                                                                 int languageId) {
        //    Argument.ShouldNotBeNull(() => subscription);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("NewsLetterSubscription.DeactivationMessage",
        //                                                            languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(subscription);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = subscription.Email;
        //    var toName = string.Empty;

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendProductEmailAFriendMessage(User user,
        //                                                  int 
        //                                                  Product product,
        //                                                  string userEmail,
        //                                                  string friendsEmail,
        //                                                  string personalMessage) {
        //    Argument.ShouldNotBeNull(() => user);
        //    Argument.ShouldNotBeNull(() => product);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("Service.EmailAFriend", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var userProductTokens = GenerateTokens(user, product);
        //    userProductTokens.Add(new Token("EmailAFriend.PersonalMessage", personalMessage, true));
        //    userProductTokens.Add(new Token("EmailAFriend.Email", userEmail));

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = friendsEmail;
        //    var toName = string.Empty;

        //    return SendNotification(messageTemplate, emailAccount,  userProductTokens, toEmail, toName);
        //}

        //public virtual int SendWishlistEmailAFriendMessage(User user,
        //                                                   int 
        //                                                   string userEmail,
        //                                                   string friendsEmail,
        //                                                   string personalMessage) {
        //    Argument.ShouldNotBeNull(() => user);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("Wishlist.EmailAFriend", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var userTokens = GenerateTokens(user);
        //    userTokens.Add(new Token("Wishlist.PersonalMessage", personalMessage, true));
        //    userTokens.Add(new Token("Wishlist.Email", userEmail));

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = friendsEmail;
        //    var toName = string.Empty;

        //    return SendNotification(messageTemplate, emailAccount,  userTokens, toEmail, toName);
        //}

        //public virtual int SendNewReturnRequestStoreOwnerNotification(ReturnRequest returnRequest,
        //                                                              OrderProductVariant orderProductVariant,
        //                                                              int languageId) {
        //    Argument.ShouldNotBeNull(() => returnRequest);
        //    Argument.ShouldNotBeNull(() => orderProductVariant);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("NewReturnRequest.StoreOwnerNotification",
        //                                                            languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(returnRequest, orderProductVariant);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = emailAccount.Email;
        //    var toName = emailAccount.DisplayName;

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public virtual int SendReturnRequestStatusChangedUserNotification(ReturnRequest returnRequest,
        //                                                                  OrderProductVariant orderProductVariant,
        //                                                                  int languageId) {
        //    Argument.ShouldNotBeNull(() => returnRequest);
        //    Argument.ShouldNotBeNull(() => orderProductVariant);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("ReturnRequestStatusChanged.UserNotification",
        //                                                            languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var orderTokens = GenerateTokens(returnRequest, orderProductVariant);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = returnRequest.User.Email;
        //    var toName = returnRequest.User.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  orderTokens, toEmail, toName);
        //}

        //public int SendNewForumTopicMessage(User user, ForumTopic forumTopic, Forum forum, int languageId) {
        //    Argument.ShouldNotBeNull(() => user);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("Forums.NewForumTopic", languageId);
        //    if (messageTemplate == null || !messageTemplate.IsActive)
        //        return 0;

        //    var tokens = GenerateTokens(forumTopic);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = user.Email;
        //    var toName = user.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  tokens, toEmail, toName);
        //}

        //public int SendNewForumPostMessage(User user,
        //                                   TopicReply forumPost,
        //                                   ForumTopic forumTopic,
        //                                   Forum forum,
        //                                   int friendlyForumTopicPageIndex,
        //                                   int languageId) {
        //    Argument.ShouldNotBeNull(() => user);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("Forums.NewForumPost", languageId);
        //    if (messageTemplate == null || !messageTemplate.IsActive)
        //        return 0;

        //    var tokens = GenerateTokens(forumPost, friendlyForumTopicPageIndex, forumPost.Id);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = user.Email;
        //    var toName = user.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  tokens, toEmail, toName);
        //}

        //public int SendPrivateMessageNotification(PrivateMessage privateMessage, int languageId) {
        //    Argument.ShouldNotBeNull(() => privateMessage);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("User.NewPM", languageId);
        //    if (messageTemplate == null || !messageTemplate.IsActive)
        //        return 0;

        //    var privateMessageTokens = GenerateTokens(privateMessage);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = privateMessage.ToUser.Email;
        //    var toName = privateMessage.ToUser.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  privateMessageTokens, toEmail, toName);
        //}

        //public virtual int SendGiftCardNotification(GiftCard giftCard, int languageId) {
        //    Argument.ShouldNotBeNull(() => giftCard);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("GiftCard.Notification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var giftCardTokens = GenerateTokens(giftCard);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = giftCard.RecipientEmail;
        //    var toName = giftCard.RecipientName;

        //    return SendNotification(messageTemplate, emailAccount,  giftCardTokens, toEmail, toName);
        //}

        //public virtual int SendProductReviewNotificationMessage(ProductReview productReview, int languageId) {
        //    Argument.ShouldNotBeNull(() => productReview);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("Product.ProductReview", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var productReviewTokens = GenerateTokens(productReview);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = emailAccount.Email;
        //    var toName = emailAccount.DisplayName;

        //    return SendNotification(messageTemplate, emailAccount,  productReviewTokens, toEmail, toName);
        //}

        //public virtual int SendQuantityBelowStoreOwnerNotification(ProductVariant productVariant, int languageId) {
        //    Argument.ShouldNotBeNull(() => productVariant);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("QuantityBelow.StoreOwnerNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var productVariantTokens = GenerateTokens(productVariant);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = emailAccount.Email;
        //    var toName = emailAccount.DisplayName;

        //    return SendNotification(messageTemplate, emailAccount,  productVariantTokens, toEmail, toName);
        //}

        //public virtual int SendNewVatSubmittedStoreOwnerNotification(User user,
        //                                                             string vatName,
        //                                                             string vatAddress,
        //                                                             int languageId) {
        //    Argument.ShouldNotBeNull(() => user);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("NewVATSubmitted.StoreOwnerNotification", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var vatSubmittedTokens = GenerateTokens(user);
        //    vatSubmittedTokens.Add(new Token("VatValidationResult.Name", vatName));
        //    vatSubmittedTokens.Add(new Token("VatValidationResult.Address", vatAddress));

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = emailAccount.Email;
        //    var toName = emailAccount.DisplayName;

        //    return SendNotification(messageTemplate, emailAccount,  vatSubmittedTokens, toEmail, toName);
        //}

        //public virtual int SendBlogCommentNotificationMessage(PostComment blogComment, int languageId) {
        //    Argument.ShouldNotBeNull(() => blogComment);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("Blog.BlogComment", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var blogCommentTokens = GenerateTokens(blogComment);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = emailAccount.Email;
        //    var toName = emailAccount.DisplayName;

        //    return SendNotification(messageTemplate, emailAccount,  blogCommentTokens, toEmail, toName);
        //}

        //public virtual int SendCommentNotificationMessage(Comment comment, int languageId) {
        //    Argument.ShouldNotBeNull(() => comment);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("News.Comment", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var commentTokens = GenerateTokens(comment);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var toEmail = emailAccount.Email;
        //    var toName = emailAccount.DisplayName;

        //    return SendNotification(messageTemplate, emailAccount,  commentTokens, toEmail, toName);
        //}

        //public virtual int SendBackInStockNotification(BackInStockSubscription subscription, int languageId) {
        //    Argument.ShouldNotBeNull(() => subscription);

        //    languageId = EnsureLanguageIsActive(languageId);

        //    var messageTemplate = GetLocalizedActiveMessageTemplate("User.BackInStock", languageId);
        //    if (messageTemplate == null)
        //        return 0;

        //    var subscriptionTokens = GenerateTokens(subscription);

        //    var emailAccount = GetNotificationEmailAccount(messageTemplate, languageId);
        //    var user = subscription.User;
        //    var toEmail = user.Email;
        //    var toName = user.GetFullName();

        //    return SendNotification(messageTemplate, emailAccount,  subscriptionTokens, toEmail, toName);
        //}
    }
}