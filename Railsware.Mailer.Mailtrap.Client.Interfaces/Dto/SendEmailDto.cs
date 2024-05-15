using System.Text.Json.Serialization;

namespace Railsware.Mailer.Mailtrap.Client.Interfaces.Dto
{
    public class SendEmailDto
    {
        [JsonPropertyName("from")]
        public SendEmailSenderDto From { get; set; }

        [JsonPropertyName("to")]
        public IEnumerable<SendEmailRecipientDto> To { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("test")]
        public string Text { get; set; }

        [JsonPropertyName("html")]
        public string Html { get; set; }

        [JsonPropertyName("attachments")]
        public IEnumerable<SendEmailAttachmentsDto> Attachments { get; set; }
    }
}