using System.Text.Json.Serialization;

namespace Railsware.Mailer.Mailtrap.Client.Interfaces.Dto
{
    public class SendEmailRecipientDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}