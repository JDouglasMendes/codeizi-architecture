using Codeizi.Service.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace Codeizi.Integration.Test
{
    public class BaseIntegrationTest
    {
        protected TestServer Server { get; }
        protected HttpClient Client { get; }

        protected BaseIntegrationTest()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = Server.CreateClient();
        }
    }
}