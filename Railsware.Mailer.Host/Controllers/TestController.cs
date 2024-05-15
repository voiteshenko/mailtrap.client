using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railsware.Mailer.Mailtrap.Client.Interfaces;

namespace Railsware.Mailer.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMailtrapClient _mailtrapClient;

        public TestController(IMailtrapClient mailtrapClient)
        {
            _mailtrapClient = mailtrapClient;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            await _mailtrapClient.Send(
                "mailtrap@demomailtrap.com",
                "v.voiteshenko@gmail.com",
                "Test from asp.net!",
                "Congrats for sending test email with Mailtrap! TEST TEST TEST TEST TEST TEST",
                "<!DOCTYPE html>\r\n<html>\r\n<body>\r\n\r\n<h1>My First Heading</h1>\r\n\r\n<p>My first paragraph.</p>\r\n\r\n</body>\r\n</html>\r\n",
                "SGVsbG8gZnJvbSBmaWxlDQo=",
                "1.txt",
                "Vlad App",
                "Vlad"
                );

            return Ok();
        }
    }
}