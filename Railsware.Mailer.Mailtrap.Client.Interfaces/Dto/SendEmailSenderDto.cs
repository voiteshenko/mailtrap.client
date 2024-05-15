using System.Text.Json.Serialization;

namespace Railsware.Mailer.Mailtrap.Client.Interfaces.Dto
{
    public class SendEmailSenderDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("from")]
        public string Name { get; set; }
    }
}