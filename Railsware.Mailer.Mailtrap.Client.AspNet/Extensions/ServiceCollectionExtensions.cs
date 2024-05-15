using Microsoft.Extensions.DependencyInjection;
using Railsware.Mailer.Mailtrap.Client.Interfaces;
using System.Net.Http.Headers;

namespace Railsware.Mailer.Mailtrap.Client.AspNet.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMailtrapClient(this IServiceCollection services, string baseUrl, string apiToken)
        {
            services.AddScoped<IMailtrapClient, MailtrapClient>();

            services.AddHttpClient(nameof(IMailtrapClient), c =>
            {
                c.BaseAddress = new Uri(baseUrl);
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            });
        }
    }
}