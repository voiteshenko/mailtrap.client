using Moq;
using Railsware.Mailer.Mailtrap.Client;
using System.Net;
using System.Net.Http;

namespace Railsware.Mailer.Tests
{
    [TestFixture]
    public class MailtrapClientTests
    {
        [Test]
        public async Task Send_Email_Success()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();

            httpClientMock
                .Setup(c => c.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>(), CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            httpClientFactoryMock
                .Setup(f => f.CreateClient(It.IsAny<string>()))
                .Returns(httpClientMock.Object);

            var mailtrapClient = new MailtrapClient(httpClientFactoryMock.Object);

            // Act
            await mailtrapClient.Send("sender@example.com", "recipient@example.com", "Test Subject", "Test Text");

            // Assert
            httpClientMock.Verify(c => c.PostAsync("/api/send", It.IsAny<StringContent>(), CancellationToken.None), Times.Once);
        }

        [Test]
        public void Send_Email_Failure_HttpClientThrowsException()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();

            httpClientMock
                .Setup(c => c.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>(), CancellationToken.None))
                .ThrowsAsync(new HttpRequestException());

            httpClientFactoryMock
                .Setup(f => f.CreateClient(It.IsAny<string>()))
                .Returns(httpClientMock.Object);

            var mailtrapClient = new MailtrapClient(httpClientFactoryMock.Object);

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () =>
                await mailtrapClient.Send("sender@example.com", "recipient@example.com", "Test Subject", "Test Text"));
        }

    }
}