using Funq;
using ServiceStack;
using NUnit.Framework;
using ModulusCheck.ServiceInterface;
using ModulusCheck.ServiceModel.Request;
using ModulusCheck.ServiceModel.Response;

namespace ModulusCheck.Tests
{
    public class IntegrationTest
    {
        const string BaseUri = "http://localhost:60939/";
        private readonly ServiceStackHost appHost;

        class AppHost : AppSelfHostBase
        {
            public AppHost() : base("ModulusCheck", 
                typeof(CheckService).Assembly) { }

            public override void Configure(Container container)
            {
            }
        }

        public IntegrationTest()
        {
            appHost = new AppHost()
                .Init()
                .Start(BaseUri);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        public IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

        [Test]
        public void CanCallCheckService()
        {
            var client = CreateClient();

            var response = client.Get(new CheckRequest{AccountNumber = " ", SortCode = " "});

            Assert.NotNull(response);
        }
    }
}