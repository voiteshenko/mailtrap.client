namespace Railsware.Mailer.Mailtrap.Client.Interfaces
{
    public interface IMailtrapClient
    {
        Task Send(
        string senderEmail,
        string recipientEmail,
        string subject,
        string text,
        string? html = null,
        string? attachments = null,
        string? fileName = null,
        string? senderName = null,
        string? recipientName = null);
    }
}