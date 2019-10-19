namespace FaraMedia.Services.Tasks {
	using System;

	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Core.Domain.Security;
	using FaraMedia.Services.Extensions.Security;
	using FaraMedia.Services.Querying.Security;
	using FaraMedia.Services.Tasks.Abstraction;

	public sealed class DeleteGuestUsersTask : ITask {
		private readonly IDbService<User, UserQuery> _userService;
		private readonly SecuritySettings _securitySettings;

		public DeleteGuestUsersTask(IDbService<User, UserQuery> userService,
		                            SecuritySettings securitySettings) {
			_userService = userService;
			_securitySettings = securitySettings;
		}

		public void Execute() {
			_userService.DeleteGuestUsers(null,
			                              DateTime.UtcNow.AddMinutes(-_securitySettings.MaxumimMinutesToDeleteGuestUsers));
		}
	}
}