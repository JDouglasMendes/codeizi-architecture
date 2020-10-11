using System.Threading.Tasks;
using Xunit;

namespace Codeizi.Integration.Test.Customer
{
    [Trait("Integration", "Customer")]
    public class CustomerControllerTest : BaseIntegrationTest
    {
        [Fact]
        public async Task Register_new_customer_()
        {
            var response = await Client.PostAsync("/api/customer", CustomerFactory.Create().ToJson());
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}