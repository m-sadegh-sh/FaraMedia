namespace FaraMedia.Core.Domain.Security {
	using System;

	using FaraMedia.Core.Domain.Billing;
	using FaraMedia.Core.Domain.ContentManagement;
	using FaraMedia.Core.Domain.Misc;
	using FaraMedia.Core.Domain.Shared;
	using FaraMedia.Core.Domain.Systematic;

	using Iesi.Collections.Generic;

	public class User : EntityBase {
		private ISet<Activity> _activities;
		private ISet<Log> _logs;
		private ISet<ToDo> _toDos;
		private ISet<Ticket> _tickets;
		private ISet<TicketResponse> _responses;
		private ISet<FriendRequest> _incomingFriendRequests;
		private ISet<FriendRequest> _outgoingFriendRequests;
		private ISet<Blog> _blogs;
		private ISet<Order> _orders;
		private ISet<Like> _likes;
		private ISet<Share> _shares;
		private ISet<PollVotingRecord> _votingRecords;
		private ISet<Role> _roles;

		public virtual string SystemName { get; set; }
		public virtual string UserName { get; set; }
		public virtual string Email { get; set; }
		public virtual string Password { get; set; }
		public virtual string PasswordSalt { get; set; }
		public virtual PasswordStoringFormat PasswordFormat { get; set; }
		public virtual DateTime? LastLoginDateUtc { get; set; }
		public virtual DateTime LastActivityDateUtc { get; set; }
		public virtual string LastIpAddress { get; set; }
		public virtual string AdminComment { get; set; }
		public virtual BlockReason CurrentBlockReason { get; set; }

		public virtual ISet<Role> Roles {
			get { return _roles ?? (_roles = new HashedSet<Role>()); }
			protected set { _roles = value; }
		}

		public virtual ISet<Activity> Activities {
			get { return _activities ?? (_activities = new HashedSet<Activity>()); }
			protected set { _activities = value; }
		}

		public virtual ISet<Log> Logs {
			get { return _logs ?? (_logs = new HashedSet<Log>()); }
			protected set { _logs = value; }
		}

		public virtual ISet<ToDo> ToDos {
			get { return _toDos ?? (_toDos = new HashedSet<ToDo>()); }
			protected set { _toDos = value; }
		}

		public virtual ISet<Ticket> Tickets {
			get { return _tickets ?? (_tickets = new HashedSet<Ticket>()); }
			protected set { _tickets = value; }
		}

		public virtual ISet<TicketResponse> Responses {
			get { return _responses ?? (_responses = new HashedSet<TicketResponse>()); }
			protected set { _responses = value; }
		}

		public virtual ISet<FriendRequest> IncomingFriendRequests {
			get { return _incomingFriendRequests ?? (_incomingFriendRequests = new HashedSet<FriendRequest>()); }
			protected set { _incomingFriendRequests = value; }
		}

		public virtual ISet<FriendRequest> OutgoingFriendRequests {
			get { return _outgoingFriendRequests ?? (_outgoingFriendRequests = new HashedSet<FriendRequest>()); }
			protected set { _outgoingFriendRequests = value; }
		}

		public virtual ISet<Blog> Blogs {
			get { return _blogs ?? (_blogs = new HashedSet<Blog>()); }
			protected set { _blogs = value; }
		}

		public virtual ISet<Order> Orders {
			get { return _orders ?? (_orders = new HashedSet<Order>()); }
			protected set { _orders = value; }
		}

		public virtual ISet<Like> Likes {
			get { return _likes ?? (_likes = new HashedSet<Like>()); }
			protected set { _likes = value; }
		}

		public virtual ISet<Share> Shares {
			get { return _shares ?? (_shares = new HashedSet<Share>()); }
			protected set { _shares = value; }
		}

		public virtual ISet<PollVotingRecord> VotingRecords {
			get { return _votingRecords ?? (_votingRecords = new HashedSet<PollVotingRecord>()); }
			protected set { _votingRecords = value; }
		}
	}
}