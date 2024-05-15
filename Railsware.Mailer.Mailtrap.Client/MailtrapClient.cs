using Newtonsoft.Json;
using Railsware.Mailer.Mailtrap.Client.Interfaces;
using Railsware.Mailer.Mailtrap.Client.Interfaces.Dto;
using System.Text;
using Formatting = Newtonsoft.Json.Formatting;

namespace Railsware.Mailer.Mailtrap.Client
{
    public class MailtrapClient : IMailtrapClient
    {
        private readonly HttpClient _httpClient;

        public MailtrapClient(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient(nameof(IMailtrapClient));
        }

        public async Task Send(
            string senderEmail,
            string recipientEmail,
            string subject,
            string text,
            string? html = null,
            string? attachments = null,
            string? fileName = null,
            string? senderName = null,
            string? recipientName = null)
        {
            var model = new SendEmailDto
            {
                From = new SendEmailSenderDto
                {
                    Email = senderEmail,
                    Name = senderName,
                },
                To = new List<SendEmailRecipientDto>
                {
                    new SendEmailRecipientDto
                    {
                        Email = recipientEmail,
                        Name = recipientName
                    }

                },
                Subject = subject,
                Text = text,
                Html = html,
                Attachments = attachments == null ? null : new List<SendEmailAttachmentsDto>()
                {
                    new SendEmailAttachmentsDto
                    {
                        Content = attachments,
                        FileName = fileName
                    }
                }
            };

            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var response = await _httpClient.PostAsync("/api/send", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}