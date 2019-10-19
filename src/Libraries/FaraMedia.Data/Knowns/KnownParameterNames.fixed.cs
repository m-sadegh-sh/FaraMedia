namespace FaraMedia.Data.Knowns {
	using FaraMedia.Data.Schemas;

	public sealed class KnownParameterNames : ConstantsBase {
		public static readonly string Page = Helpers.Key<KnownParameterNames, string>(kpn => Page);
		public static readonly string Size = Helpers.Key<KnownParameterNames, string>(kpn => Size);
		public static readonly string Id = Helpers.Key<KnownParameterNames, string>(kpn => Id);
		public static readonly string ParentId = Helpers.Key<KnownParameterNames, string>(kpn => ParentId);
		public static readonly string OwnerId = Helpers.Key<KnownParameterNames, string>(kpn => OwnerId);

		public static readonly string OrderId = Helpers.Key<KnownParameterNames, string>(kpn => OrderId);
		public static readonly string OrderLineId = Helpers.Key<KnownParameterNames, string>(kpn => OrderLineId);
		public static readonly string OrderNoteId = Helpers.Key<KnownParameterNames, string>(kpn => OrderNoteId);
		public static readonly string OrderStatusId = Helpers.Key<KnownParameterNames, string>(kpn => OrderStatusId);
		public static readonly string TransactionRequestId = Helpers.Key<KnownParameterNames, string>(kpn => TransactionRequestId);
		public static readonly string TransactionResponseId = Helpers.Key<KnownParameterNames, string>(kpn => TransactionResponseId);

		public static readonly string SettingId = Helpers.Key<KnownParameterNames, string>(kpn => SettingId);

		public static readonly string BlogId = Helpers.Key<KnownParameterNames, string>(kpn => BlogId);
		public static readonly string CategoryId = Helpers.Key<KnownParameterNames, string>(kpn => CategoryId);
		public static readonly string GroupId = Helpers.Key<KnownParameterNames, string>(kpn => GroupId);
		public static readonly string NewsId = Helpers.Key<KnownParameterNames, string>(kpn => NewsId);
		public static readonly string PageId = Helpers.Key<KnownParameterNames, string>(kpn => PageId);
		public static readonly string PollId = Helpers.Key<KnownParameterNames, string>(kpn => PollId);
		public static readonly string PollChoiceId = Helpers.Key<KnownParameterNames, string>(kpn => PollChoiceId);
		public static readonly string PollChoiceItemId = Helpers.Key<KnownParameterNames, string>(kpn => PollChoiceItemId);
		public static readonly string PollVotingRecordId = Helpers.Key<KnownParameterNames, string>(kpn => PollVotingRecordId);
		public static readonly string PostId = Helpers.Key<KnownParameterNames, string>(kpn => PostId);
		public static readonly string TagId = Helpers.Key<KnownParameterNames, string>(kpn => TagId);

		public static readonly string DownloadId = Helpers.Key<KnownParameterNames, string>(kpn => DownloadId);
		public static readonly string PictureId = Helpers.Key<KnownParameterNames, string>(kpn => PictureId);

		public static readonly string AlbumId = Helpers.Key<KnownParameterNames, string>(kpn => AlbumId);
		public static readonly string ArtistId = Helpers.Key<KnownParameterNames, string>(kpn => ArtistId);
		public static readonly string GenreId = Helpers.Key<KnownParameterNames, string>(kpn => GenreId);
		public static readonly string PhotoId = Helpers.Key<KnownParameterNames, string>(kpn => PhotoId);
		public static readonly string PhotoAlbumId = Helpers.Key<KnownParameterNames, string>(kpn => PhotoAlbumId);
		public static readonly string PublisherId = Helpers.Key<KnownParameterNames, string>(kpn => PublisherId);
		public static readonly string TrackId = Helpers.Key<KnownParameterNames, string>(kpn => TrackId);

		public static readonly string RedirectorId = Helpers.Key<KnownParameterNames, string>(kpn => RedirectorId);
		public static readonly string TicketId = Helpers.Key<KnownParameterNames, string>(kpn => TicketId);
		public static readonly string TicketResponseId = Helpers.Key<KnownParameterNames, string>(kpn => TicketResponseId);
		public static readonly string ToDoId = Helpers.Key<KnownParameterNames, string>(kpn => ToDoId);

		public static readonly string BannedIpId = Helpers.Key<KnownParameterNames, string>(kpn => BannedIpId);
		public static readonly string BlockReasonId = Helpers.Key<KnownParameterNames, string>(kpn => BlockReasonId);
		public static readonly string FriendRequestId = Helpers.Key<KnownParameterNames, string>(kpn => FriendRequestId);
		public static readonly string PermissionRecordId = Helpers.Key<KnownParameterNames, string>(kpn => PermissionRecordId);
		public static readonly string RoleId = Helpers.Key<KnownParameterNames, string>(kpn => RoleId);
		public static readonly string UserId = Helpers.Key<KnownParameterNames, string>(kpn => UserId);

		public static readonly string CommentId = Helpers.Key<KnownParameterNames, string>(kpn => CommentId);
		public static readonly string EntityAttributeId = Helpers.Key<KnownParameterNames, string>(kpn => EntityAttributeId);
		public static readonly string LikeId = Helpers.Key<KnownParameterNames, string>(kpn => LikeId);
		public static readonly string ShareId = Helpers.Key<KnownParameterNames, string>(kpn => ShareId);

		public static readonly string ActivityId = Helpers.Key<KnownParameterNames, string>(kpn => ActivityId);
		public static readonly string ActivityTypeId = Helpers.Key<KnownParameterNames, string>(kpn => ActivityTypeId);
		public static readonly string EmailAccountId = Helpers.Key<KnownParameterNames, string>(kpn => EmailAccountId);
		public static readonly string LanguageId = Helpers.Key<KnownParameterNames, string>(kpn => LanguageId);
		public static readonly string LogId = Helpers.Key<KnownParameterNames, string>(kpn => LogId);
		public static readonly string MessageTemplateId = Helpers.Key<KnownParameterNames, string>(kpn => MessageTemplateId);
		public static readonly string NewsletterSubscriptionId = Helpers.Key<KnownParameterNames, string>(kpn => NewsletterSubscriptionId);
		public static readonly string QueuedEmailId = Helpers.Key<KnownParameterNames, string>(kpn => QueuedEmailId);
		public static readonly string ResourceKeyId = Helpers.Key<KnownParameterNames, string>(kpn => ActivityTypeId);
		public static readonly string ResourceValueId = Helpers.Key<KnownParameterNames, string>(kpn => ResourceValueId);
		public static readonly string ScheduleTaskId = Helpers.Key<KnownParameterNames, string>(kpn => ScheduleTaskId);
	}
}