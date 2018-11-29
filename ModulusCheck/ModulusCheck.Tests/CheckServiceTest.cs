using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using ModulusCheck.ServiceInterface;
using ModulusCheck.ServiceModel;
using ModulusCheck.ServiceModel.Request;
using ModulusCheck.ServiceModel.Response;

namespace ModulusCheck.Tests
{
    public class CheckServiceTest
    {
        private readonly ServiceStackHost appHost;

        public CheckServiceTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<CheckService>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        [Test]
        public void CanCallCheckService()
        {
            var service = appHost.Container.Resolve<CheckService>();

            var response = (CheckResponse)service.Any(new CheckRequest
            {
                AccountNumber = string.Empty,
                SortCode = string.Empty
            });
            Assert.False(response.IsValid);
            Assert.That(response.Message, Is.EqualTo("Invalid request."));
        }
    }
}
