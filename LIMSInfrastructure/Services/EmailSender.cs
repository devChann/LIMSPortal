using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace LIMSInfrastructure.Services
{
	// This class is used by the application to send email for account confirmation and password reset.
	// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
	public class EmailSender: IEmailSender
    {
		////public Task SendEmailAsync(string email, string subject, string message)
		////{
		////    return Task.CompletedTask;
		////}

		//public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
		//{
		//    Options = optionsAccessor.Value;
		//}

		//public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

		//public Task SendEmailAsync(string email, string subject, string message)
		//{
		//    return Execute(Options.SendGridKey, subject, message, email);
		//}

		//public Task Execute(string apiKey, string subject, string message, string email)
		//{
		//    var client = new SendGridClient(apiKey);
		//    var msg = new SendGridMessage()
		//    {
		//        From = new EmailAddress("ayiembaelvis@gmail.com", "LIMS Portal"),
		//        Subject = subject,
		//        PlainTextContent = message,
		//        HtmlContent = message
		//    };
		//    msg.AddTo(new EmailAddress(email));
		//    return client.SendEmailAsync(msg);
		//}

		

		private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {

            // Don't do anything if SendGrid isn't configured
            if (string.IsNullOrEmpty(_configuration["SendGridKey"])) return;

            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("ayiembaelvis@gmail.com", "No Reply"));

            var recipient = new EmailAddress(recipientEmail);

            msg.AddTo(recipient);
            msg.SetSubject(subject);

            // TODO: Permalink to comment
            msg.AddContent(MimeType.Html, body);

            var apiKey = _configuration["SendGridKey"];

            var client = new SendGridClient(apiKey);

            var response = await client.SendEmailAsync(msg);

        }

		public Task SendEmailConfirmationAsyn(string email, string callbackUrl)
		{
			throw new NotImplementedException();
		}

	}
}
