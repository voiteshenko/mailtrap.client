using System.Text.Json.Serialization;

namespace Railsware.Mailer.Mailtrap.Client.Interfaces.Dto
{
    public class SendEmailAttachmentsDto
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("filename")]
        public string FileName { get; set; }
    }
}