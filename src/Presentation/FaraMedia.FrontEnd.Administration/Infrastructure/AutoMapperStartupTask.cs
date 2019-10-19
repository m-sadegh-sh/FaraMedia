namespace FaraMedia.FrontEnd.Administration.Infrastructure {
    using System;
    using System.Linq;

    using AutoMapper;

    using FaraMedia.AutoMapperIntegration.Converters;
    using FaraMedia.AutoMapperIntegration.Resolvers;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.Common;
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Domain.FileManagement;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.Billing;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Miscellaneous;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Domain.Miscellaneous;
    using FaraMedia.Core.Domain.Fundamentals;
    using FaraMedia.Core.Domain.Miscellaneous;
    using FaraMedia.Core.Globalization;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Core.Infrastructure.Extensions;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Billing;
    using FaraMedia.FrontEnd.Administration.Models.Blogs;
    using FaraMedia.FrontEnd.Administration.Models.Blogs.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Common;
    using FaraMedia.FrontEnd.Administration.Models.Common.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Components.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Configuration;
    using FaraMedia.FrontEnd.Administration.Models.Configuration.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.FrontEnd.Administration.Models.Systematic.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.FrontEnd.Administration.Models.Systematic.Editable;
    using FaraMedia.FrontEnd.Administration.Models.FileManagement;
    using FaraMedia.FrontEnd.Administration.Models.FileManagement.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.FrontEnd.Administration.Models.Security.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.FrontEnd.Administration.Models.Systematic.Editable;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Billing;
    using FaraMedia.FrontEnd.Administration.Models.Billing.Editable;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement;
    using FaraMedia.FrontEnd.Administration.Models.ContentManagement.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Security;
    using FaraMedia.FrontEnd.Administration.Models.Security.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Configuration;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Systematic;
    using FaraMedia.FrontEnd.Administration.Models.Systematic.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals;
    using FaraMedia.FrontEnd.Administration.Models.Fundamentals.Editable;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous;
    using FaraMedia.FrontEnd.Administration.Models.Miscellaneous.Editable;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Services.ContentManagement;
    using FaraMedia.Services.Fundamentals;
    using FaraMedia.Web.Framework.Mvc.Models;
    using FaraMedia.Web.Framework.Mvc.Models.Editable;

    public class AutoMapperStartupTask : IStartupTask {
        public int ExecutionOrder {
            get { return 0; }
        }

        public void Execute() {
            CreateHelperMappers();

            CreateCommonMappers();

            CreateComponentMappers();

            CreateGenreMappers();

            CreatePublisherMappers();

            CreateArtistMappers();

            CreateAlbumMappers();

            CreateBillingMappers();

            CreateNewsMappers();

            CreateBloggingMappers();

            CreateMediaMappers();

            CreateStatisticsMappers();

            CreateSettingsMappers();
        }

        private static void CreateHelperMappers() {
            Mapper.CreateMap<string, string>().ConvertUsing<NullOrEmptyStringToStringConverter>();
            Mapper.CreateMap<bool, string>().ConvertUsing<BoolToStringConverter>();
            Mapper.CreateMap<DateTime, MultiFormatDateTime>().ConvertUsing<DateTimeToMultiFormatDateTimeConverter>();
            Mapper.CreateMap<DateTime?, MultiFormatDateTime>().ConvertUsing<NullableDateTimeToMultiFormatDateTimeConverter>();
        }

        private static void CreateCommonMappers() {
            Mapper.CreateMap<EntityBase, EntityModelBase>().ForMember(em => em.CreatedOn, mce => mce.ResolveUsing<UtcDateTimeToDateTimeResolver>().FromMember(e => e.CreatedOnUtc)).ForMember(em => em.LastModifiedOn, mce => mce.ResolveUsing<UtcDateTimeToDateTimeResolver>().FromMember(e => e.LastModifiedOnUtc)).Include<UserContentBase, UserContentModelBase>().Include<EntityAttributeBase, EntityAttributeModelBase>().Include<TransactionDebug, TransactionDebugModel>().Include<Tag, TagModel>().Include<Setting, SettingModel>().Include<Language, LanguageModel>().Include<StringResource, StringResourceModel>().Include<ActivityType, ActivityTypeModel>().Include<Activity, ActivityModel>().Include<Log, LogModel>().Include<Role, RoleModel>().Include<User, UserModel>().Include<FriendRequest, FriendRequestModel>().Include<EmailAccount, EmailAccountModel>().Include<MessageTemplate, MessageTemplateModel>().Include<NewsletterSubscription, NewsletterSubscriptionModel>().Include<QueuedEmail, QueuedEmailModel>().Include<Category, CategoryModel>().Include<Order, OrderModel>().Include<OrderNote, OrderNoteModel>().Include<OrderLine, OrderLineModel>().Include<OrderLineDownload, OrderLineDownloadModel>().Include<Group, GroupModel>().Include<Page, PageModel>().Include<Poll, PollModel>().Include<PollAnswer, PollAnswerModel>().Include<BannedIp, BannedIpModel>().Include<PermissionRecord, PermissionRecordModel>().Include<Redirector, RedirectorModel>().Include<ScheduleTask, ScheduleTaskModel>().Include<Ticket, TicketModel>().Include<TicketResponse, TicketResponseModel>().Include<ToDo, ToDoModel>();

            Mapper.CreateMap<EntityBase, EditableEntityModelBase>().Include<UserContentBase, EditableUserContentModelBase>().Include<EntityAttributeBase, EditableEntityAttributeModel>().Include<Tag, EditableTagModel>().Include<Setting, EditableSettingModel>().Include<Language, EditableLanguageModel>().Include<StringResource, EditableStringResourceModel>().Include<ActivityType, EditableActivityTypeModel>().Include<Activity, EditableActivityModel>().Include<Log, EditableLogModel>().Include<Role, EditableRoleModel>().Include<User, EditableUserModel>().Include<FriendRequest, EditableFriendRequestModel>().Include<EmailAccount, EditableEmailAccountModel>().Include<MessageTemplate, EditableMessageTemplateModel>().Include<NewsletterSubscription, EditableNewsletterSubscriptionModel>().Include<QueuedEmail, EditableQueuedEmailModel>().Include<Category, EditableCategoryModel>().Include<Order, EditableOrderModel>().Include<OrderNote, EditableOrderNoteModel>().Include<OrderLine, EditableOrderLineModel>().Include<OrderLineDownload, EditableOrderLineDownloadModel>().Include<Group, EditableGroupModel>().Include<Page, EditablePageModel>().Include<Poll, EditablePollModel>().Include<PollAnswer, EditablePollAnswerModel>().Include<BannedIp, EditableBannedIpModel>().Include<PermissionRecord, EditablePermissionRecordModel>().Include<Redirector, EditableRedirectorModel>().Include<ScheduleTask, EditableScheduleTaskModel>().Include<Ticket, EditableTicketModel>().Include<TicketResponse, EditableTicketResponseModel>().Include<ToDo, EditableToDoModel>();

            Mapper.CreateMap<EditableEntityModelBase, EntityBase>().Include<EditableUserContentModelBase, UserContentBase>().Include<EditableEntityAttributeModel, EntityAttributeBase>().Include<EditableTagModel, Tag>().Include<EditableSettingModel, Setting>().Include<EditableLanguageModel, Language>().Include<EditableStringResourceModel, StringResource>().Include<EditableActivityTypeModel, ActivityType>().Include<EditableActivityModel, Activity>().Include<EditableLogModel, Log>().Include<EditableRoleModel, Role>().Include<EditableUserModel, User>().Include<EditableFriendRequestModel, FriendRequest>().Include<EditableEmailAccountModel, EmailAccount>().Include<EditableMessageTemplateModel, MessageTemplate>().Include<EditableNewsletterSubscriptionModel, NewsletterSubscription>().Include<EditableQueuedEmailModel, QueuedEmail>().Include<EditableCategoryModel, Category>().Include<EditableOrderModel, Order>().Include<EditableOrderNoteModel, OrderNote>().Include<EditableOrderLineModel, OrderLine>().Include<EditableOrderLineDownloadModel, OrderLineDownload>().Include<EditableGroupModel, Group>().Include<EditablePageModel, Page>().Include<EditablePollModel, Poll>().Include<EditablePollAnswerModel, PollAnswer>().Include<EditableBannedIpModel, BannedIp>().Include<EditablePermissionRecordModel, PermissionRecord>().Include<EditableRedirectorModel, Redirector>().Include<EditableScheduleTaskModel, ScheduleTask>().Include<EditableTicketModel, Ticket>().Include<EditableTicketResponseModel, TicketResponse>().Include<EditableToDoModel, ToDo>();

            Mapper.CreateMap<UserContentBase, UserContentModelBase>().Include<CommentableBase, CommentableModelBase>().Include<Download, DownloadModel>().Include<Picture, PictureModel>().Include<PollVotingRecord, PollVotingRecordModel>();

            Mapper.CreateMap<UserContentBase, EditableUserContentModelBase>().Include<CommentableBase, EditableCommentableModelBase>().Include<Download, EditableDownloadModel>().Include<Picture, EditablePictureModel>().Include<PollVotingRecord, EditablePollVotingRecordModel>();

            Mapper.CreateMap<EditableUserContentModelBase, UserContentBase>().Include<EditableCommentableModelBase, CommentableBase>().Include<EditableDownloadModel, Download>().Include<EditablePictureModel, Picture>().Include<EditablePollVotingRecordModel, PollVotingRecord>();

            Mapper.CreateMap<EntityAttributeBase, EntityAttributeModelBase>().Include<DownloadAttribute, DownloadAttributeModel>().Include<PictureAttribute, PictureAttributeModel>().Include<UserAttribute, UserAttributeModel>();

            Mapper.CreateMap<EntityAttributeBase, EditableEntityAttributeModel>().Include<DownloadAttribute, EditableDownloadAttributeModel>().Include<PictureAttribute, EditablePictureAttributeModel>().Include<UserAttribute, EditableUserAttributeModel>();

            Mapper.CreateMap<EditableEntityAttributeModel, EntityAttributeBase>().Include<EditableDownloadAttributeModel, DownloadAttribute>().Include<EditablePictureAttributeModel, PictureAttribute>().Include<EditableUserAttributeModel, UserAttribute>();

            Mapper.CreateMap<CommentableBase, CommentableModelBase>().Include<Album, AlbumModel>().Include<Genre, GenreModel>().Include<Artist, ArtistModel>().Include<PhotoAlbum, PhotoAlbumModel>().Include<Photo, PhotoModel>().Include<Post, PostModel>().Include<News, NewsModel>().Include<Publisher, PublisherModel>().Include<Track, TrackModel>();

            Mapper.CreateMap<CommentableBase, EditableCommentableModelBase>().Include<Album, EditableAlbumModel>().Include<Genre, EditableGenreModel>().Include<Artist, EditableArtistModel>().Include<PhotoAlbum, EditablePhotoAlbumModel>().Include<Photo, EditablePhotoModel>().Include<Post, EditablePostModel>().Include<News, EditableNewsModel>().Include<Publisher, EditablePublisherModel>().Include<Track, EditableTrackModel>();

            Mapper.CreateMap<EditableCommentableModelBase, CommentableBase>().Include<EditableAlbumModel, Album>().Include<EditableGenreModel, Genre>().Include<EditableArtistModel, Artist>().Include<EditablePhotoAlbumModel, PhotoAlbum>().Include<EditablePhotoModel, Photo>().Include<EditablePostModel, Post>().Include<EditableNewsModel, News>().Include<EditablePublisherModel, Publisher>().Include<EditableTrackModel, Track>();
        }

        private static void CreateComponentMappers() {
            Mapper.CreateMap<MetadataComponent, EditableMetadataComponentModel>();
            Mapper.CreateMap<EditableMetadataComponentModel, MetadataComponent>();
        }

        private static void CreateGenreMappers() {
            Mapper.CreateMap<Genre, GenreModel>().ForMember(gm => gm.CommentsCount,mec => mec.MapFrom(g => EngineContext.Current.Resolve<IGenreCommentService>().GetAllGenreCommentsByGenreId(g.Id).Count())).ForMember(gm => gm.LikesCount, mec => mec.MapFrom(g => EngineContext.Current.Resolve<IGenreLikeService>().GetAllGenreLikesByGenreId(g.Id).Count())).ForMember(gm => gm.SharesCount, mec => mec.MapFrom(g => EngineContext.Current.Resolve<IGenreShareService>().GetAllGenreSharesByGenreId(g.Id).Count()));

            Mapper.CreateMap<Genre, EditableGenreModel>();

            Mapper.CreateMap<EditableGenreModel, Genre>();
        }

        private static void CreatePublisherMappers() {
            Mapper.CreateMap<Publisher, PublisherModel>().ForMember(pm => pm.CommentsCount, mec => mec.MapFrom(p => EngineContext.Current.Resolve<IPublisherCommentService>().GetAllPublisherCommentsByPublisherId(p.Id).Count())).ForMember(pm => pm.LikesCount, mec => mec.MapFrom(p => EngineContext.Current.Resolve<IPublisherLikeService>().GetAllPublisherLikesByPublisherId(p.Id).Count())).ForMember(pm => pm.SharesCount, mec => mec.MapFrom(p => EngineContext.Current.Resolve<IPublisherShareService>().GetAllPublisherSharesByPublisherId(p.Id).Count()));

            Mapper.CreateMap<Publisher, EditablePublisherModel>();

            Mapper.CreateMap<EditablePublisherModel, Publisher>().ForMember(p => p.Website, mce => mce.MapFrom(epm => !string.IsNullOrWhiteSpace(epm.WebsiteTargetUrl) ? new Redirector {
                TargetUrl = epm.WebsiteTargetUrl
            } : null)).ForMember(p => p.Logo, mce => mce.MapFrom(epm => epm.LogoId.GetValueOrDefault(0) > 0 ? new Picture {
                Id = epm.LogoId.Value
            } : null));
        }

        private static void CreateArtistMappers() {
            Mapper.CreateMap<Artist, ArtistModel>().ForMember(am => am.BirthDate, mce => mce.ResolveUsing<UtcDateTimeToDateTimeResolver>().FromMember(a => a.BirthDateUtc)).ForMember(am => am.CommentsCount, mec => mec.MapFrom(a => EngineContext.Current.Resolve<IArtistCommentService>().GetAllArtistCommentsByArtistId(a.Id).Count())).ForMember(am => am.LikesCount, mec => mec.MapFrom(a => EngineContext.Current.Resolve<IArtistLikeService>().GetAllArtistLikesByArtistId(a.Id).Count())).ForMember(am => am.SharesCount, mec => mec.MapFrom(a => EngineContext.Current.Resolve<IArtistShareService>().GetAllArtistSharesByArtistId(a.Id).Count()));

            Mapper.CreateMap<Artist, EditableArtistModel>().ForMember(eam => eam.BirthDateDay, mce => mce.ResolveUsing<UtcDateTimeToDayResolver>().FromMember(a => a.BirthDateUtc)).ForMember(eam => eam.BirthDateMonth, mce => mce.ResolveUsing<UtcDateTimeToMonthResolver>().FromMember(a => a.BirthDateUtc)).ForMember(eam => eam.BirthDateYear, mce => mce.ResolveUsing<UtcDateTimeToYearResolver>().FromMember(a => a.BirthDateUtc));

            Mapper.CreateMap<EditableArtistModel, Artist>().ForMember(a => a.BirthDateUtc, mce => mce.MapFrom(eam => new DayMonthYearToUtcDateTimeResolver(eam.BirthDateYear, eam.BirthDateMonth, eam.BirthDateDay).Resolve())).ForMember(a => a.Avatar, mce => mce.MapFrom(eam => !string.IsNullOrEmpty(eam.FacebookTargetUrl)  ? new Redirector {
                TargetUrl = eam.FacebookTargetUrl
            } : null)).ForMember(a => a.Avatar, mce => mce.MapFrom(eam => eam.AvatarId.GetValueOrDefault(0) > 0 ? new Picture {
                Id = (long)eam.AvatarId
            } : null));
        }

        private static void CreateAlbumMappers() {
            Mapper.CreateMap<Album, AlbumModel>().ForMember(am => am.ReleaseDate, mce => mce.ResolveUsing<UtcDateTimeToDateTimeResolver>().FromMember(a => a.ReleaseDateUtc)).ForMember(am => am.CommentsCount, mec => mec.MapFrom(a => EngineContext.Current.Resolve<IAlbumCommentService>().GetAllAlbumCommentsByAlbumId(a.Id).Count())).ForMember(am => am.LikesCount, mec => mec.MapFrom(a => EngineContext.Current.Resolve<IAlbumLikeService>().GetAllAlbumLikesByAlbumId(a.Id).Count())).ForMember(am => am.SharesCount, mec => mec.MapFrom(a => EngineContext.Current.Resolve<IAlbumShareService>().GetAllAlbumSharesByAlbumId(a.Id).Count()));

            Mapper.CreateMap<Album, EditableAlbumModel>().ForMember(eam => eam.ReleaseDateDay, mce => mce.ResolveUsing<UtcDateTimeToDayResolver>().FromMember(a => a.ReleaseDateUtc)).ForMember(eam => eam.ReleaseDateMonth, mce => mce.ResolveUsing<UtcDateTimeToMonthResolver>().FromMember(a => a.ReleaseDateUtc)).ForMember(eam => eam.ReleaseDateYear, mce => mce.ResolveUsing<UtcDateTimeToYearResolver>().FromMember(a => a.ReleaseDateUtc));

            Mapper.CreateMap<EditableAlbumModel, Album>().ForMember(a => a.ReleaseDateUtc, mce => mce.MapFrom(eam => new DayMonthYearToUtcDateTimeResolver(eam.ReleaseDateYear, eam.ReleaseDateMonth, eam.ReleaseDateDay).Resolve())).ForMember(a => a.Publisher, mce => mce.MapFrom(eam => eam.PublisherId.GetValueOrDefault(0) > 0 ? new Publisher {
                Id = (long)eam.PublisherId
            } : null));
        }

        private static void CreateBillingMappers() {
            Mapper.CreateMap<TransactionDebug, TransactionDebugModel>();
        }

        private static void CreateNewsMappers() {
            Mapper.CreateMap<Category, CategoryModel>();

            Mapper.CreateMap<Category, EditableCategoryModel>();

            Mapper.CreateMap<EditableCategoryModel, Category>().ForMember(c => c.Parent, mce => mce.MapFrom(ecm => ecm.ParentId.GetValueOrDefault(0) > 0 ? new Category {
                Id = ecm.ParentId.Value
            } : null));

            Mapper.CreateMap<News, NewsModel>().ForMember(nm => nm.CommentsCount, mec => mec.MapFrom(n => EngineContext.Current.Resolve<INewsCommentService>().GetAllNewsCommentsByNewsId(n.Id).Count())).ForMember(nm => nm.LikesCount, mec => mec.MapFrom(n => EngineContext.Current.Resolve<INewsLikeService>().GetAllNewsLikesByNewsId(n.Id).Count())).ForMember(nm => nm.SharesCount, mec => mec.MapFrom(n => EngineContext.Current.Resolve<INewsShareService>().GetAllNewsSharesByNewsId(n.Id).Count()));

            Mapper.CreateMap<News, EditableNewsModel>();

            Mapper.CreateMap<EditableNewsModel, News>().ForMember(n => n.Category, mce => mce.MapFrom(enm => enm.CategoryId > 0 ? new Category {
                Id = enm.CategoryId
            } : null));
        }

        private static void CreateBloggingMappers() {
            Mapper.CreateMap<Blog, BlogModel>();

            Mapper.CreateMap<Blog, EditableBlogModel>();

            Mapper.CreateMap<EditableBlogModel, Blog>();

            Mapper.CreateMap<Tag, TagModel>();

            Mapper.CreateMap<Tag, EditableTagModel>();

            Mapper.CreateMap<EditableTagModel, Tag>();

            Mapper.CreateMap<Post, PostModel>().ForMember(pm => pm.CommentsCount, mec => mec.MapFrom(p => EngineContext.Current.Resolve<IPostCommentService>().GetAllPostCommentsByPostId(p.Id).Count())).ForMember(pm => pm.LikesCount, mec => mec.MapFrom(p => EngineContext.Current.Resolve<IPostLikeService>().GetAllPostLikesByPostId(p.Id).Count())).ForMember(pm => pm.SharesCount, mec => mec.MapFrom(p => EngineContext.Current.Resolve<IPostShareService>().GetAllPostSharesByPostId(p.Id).Count()));

            Mapper.CreateMap<Post, EditablePostModel>().ForMember(epm=>epm.Tags,mce=>mce.MapFrom(p=>p.Tags.Select(t=>t.Id)));

            Mapper.CreateMap<EditablePostModel, Post>().ForMember(p => p.Tags, mce => mce.MapFrom(epm => !epm.Tags.IsEmpty() ?epm.Tags.Select(t=>new Tag {
                Id = t
            }) : null));
        }

        private static void CreateMediaMappers()
        {
            Mapper.CreateMap<Download, DownloadModel>();

            Mapper.CreateMap<Download, EditableDownloadModel>();

            Mapper.CreateMap<EditableDownloadModel, Download>().ForMember(d => d.DownloadUrl, mce => mce.MapFrom(edm =>!string.IsNullOrEmpty(edm.DownloadUrl) ? new Redirector {
                TargetUrl = edm.DownloadUrl
            } : null));
            
            Mapper.CreateMap<Picture, PictureModel>();

            Mapper.CreateMap<Picture, EditablePictureModel>();

            Mapper.CreateMap<EditablePictureModel, Picture>();
        }

        private static void CreateStatisticsMappers() {
            Mapper.CreateMap<Redirector, RedirectorModel>();

            Mapper.CreateMap<Redirector, EditableRedirectorModel>();

            Mapper.CreateMap<EditableRedirectorModel, Redirector>();
        }

        private static void CreateSettingsMappers() {
            Mapper.CreateMap<AdminAreaSettings, EditableAdminAreaSettingsModel>();
            Mapper.CreateMap<EditableAdminAreaSettingsModel, AdminAreaSettings>();

            Mapper.CreateMap<ApplicationSettings, EditableApplicationSettingsModel>();
            Mapper.CreateMap<EditableApplicationSettingsModel, ApplicationSettings>();

            Mapper.CreateMap<BillingSettings, EditableBillingSettingsModel>();
            Mapper.CreateMap<EditableBillingSettingsModel, BillingSettings>();

            Mapper.CreateMap<ContentManagementSettings, EditableContentSettingsModel>();
            Mapper.CreateMap<EditableContentSettingsModel, ContentManagementSettings>();

            Mapper.CreateMap<CdnSettings, EditableCdnSettingsModel>();
            Mapper.CreateMap<EditableCdnSettingsModel, CdnSettings>();

            Mapper.CreateMap<CommonSettings, EditableCommonSettingsModel>();
            Mapper.CreateMap<EditableCommonSettingsModel, CommonSettings>();

            Mapper.CreateMap<DateTimeSettings, EditableDateTimeSettingsModel>();
            Mapper.CreateMap<EditableDateTimeSettingsModel, DateTimeSettings>();

            Mapper.CreateMap<EmailAccountSettings, EditableEmailAccountSettingsModel>();
            Mapper.CreateMap<EditableEmailAccountSettingsModel, EmailAccountSettings>();

            Mapper.CreateMap<LocalizationSettings, EditableLocalizationSettingsModel>();
            Mapper.CreateMap<EditableLocalizationSettingsModel, LocalizationSettings>();

            Mapper.CreateMap<FileManagementSettings, EditableFileManagementSettingsModel>();
            Mapper.CreateMap<EditableFileManagementSettingsModel, FileManagementSettings>();

            Mapper.CreateMap<MembershipSettings, EditableMembershipSettingsModel>();
            Mapper.CreateMap<EditableMembershipSettingsModel, MembershipSettings>();

            Mapper.CreateMap<SystemSettings, EditableMessageTemplateSettingsModel>();
            Mapper.CreateMap<EditableMessageTemplateSettingsModel, SystemSettings>();

            Mapper.CreateMap<NewsSettings, EditableNewsSettingsModel>();
            Mapper.CreateMap<EditableNewsSettingsModel, NewsSettings>();

            Mapper.CreateMap<SecuritySettings, EditableSecuritySettingsModel>();
            Mapper.CreateMap<EditableSecuritySettingsModel, SecuritySettings>();

            Mapper.CreateMap<SeoSettings, EditableSeoSettingsModel>();
            Mapper.CreateMap<EditableSeoSettingsModel, SeoSettings>();

            Mapper.CreateMap<SitemapSettings, EditableSitemapSettingsModel>();
            Mapper.CreateMap<EditableSitemapSettingsModel, SitemapSettings>();

            Mapper.CreateMap<MiscellaneousSettings, EditableMiscellaneousSettingsModel>();
            Mapper.CreateMap<EditableMiscellaneousSettingsModel, MiscellaneousSettings>();
        }
    }
}