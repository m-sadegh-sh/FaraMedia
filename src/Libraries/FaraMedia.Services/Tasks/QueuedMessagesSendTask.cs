namespace FaraMedia.Services.Tasks {
	using System;

	using FaraMedia.Core.Domain.Systematic;
	using FaraMedia.Services.Extensions.Systematic;
	using FaraMedia.Services.Querying.Systematic;
	using FaraMedia.Services.Tasks.Abstraction;
	using FaraMedia.Services.Utilities;

	public sealed class QueuedMessagesSendTask : ITask {
		private readonly IDbService<QueuedEmail, QueuedEmailQuery> _queuedEmailService;
		private readonly IDbService<Log, LogQuery> _logService;
		private readonly IEmailSender _emailSender;

		public QueuedMessagesSendTask(IDbService<QueuedEmail, QueuedEmailQuery> queuedEmailService,
		                              IDbService<Log, LogQuery> logService,
		                              IEmailSender emailSender) {
			_queuedEmailService = queuedEmailService;
			_logService = logService;
			_emailSender = emailSender;
		}

		public void Execute() {
			const int maxTries = 3;

			var queuedEmails = _queuedEmailService.GetAll(qeq => qeq.WithSendingTries(maxTries));

			foreach (var queuedEmail in queuedEmails) {
				var bcc = string.IsNullOrWhiteSpace(queuedEmail.Bcc) ? null : queuedEmail.Bcc.Split(new[] {';'},
				                                                                                    StringSplitOptions.RemoveEmptyEntries);
				var cc = string.IsNullOrWhiteSpace(queuedEmail.Cc) ? null : queuedEmail.Cc.Split(new[] {';'},
				                                                                                 StringSplitOptions.RemoveEmptyEntries);

				try {
					_emailSender.SendEmail(queuedEmail.EmailAccount,
					                       queuedEmail.Subject,
					                       queuedEmail.Body,
					                       queuedEmail.From,
					                       queuedEmail.FromName,
					                       queuedEmail.To,
					                       queuedEmail.ToName,
					                       bcc,
					                       cc);

					queuedEmail.SentDateUtc = DateTime.UtcNow;
				} catch (Exception exception) {
					_logService.Error(string.Format("Error sending e-mail. {0}",
					                                exception.Message),
					                  exception);
				} finally {
					queuedEmail.SendingTries += 1;
					_queuedEmailService.Save(queuedEmail);
				}
			}
		}
	}
}