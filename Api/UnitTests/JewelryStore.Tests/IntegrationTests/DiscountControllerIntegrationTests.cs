using JewerlyStore;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStore.Tests.IntegrationTests
{
    public class DiscountControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public DiscountControllerIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Post_Should_Return_OkResponse()
        {
            var client = _factory.CreateClient();
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiU3RldmUiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjY3ZjU4MTQ5LTc0ODMtNGM0MS1iNDkyLTdiZDhlOTY3MDBjZCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImFkNWNkYmRmLWI1ZGYtNGJiZS1hOTRhLWNhZmY3ZGU1YmVkYSIsImV4cCI6MTYyMDk5NzY3MywiaXNzIjoiSmV3ZWxyeVNob3AiLCJhdWQiOiJKZXdlbHJ5U2hvcCJ9.OUSz5WA8JnMOq144goDCscQoo1GVHA-ZfDerom0hZw8";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "/api/discount/getDiscount");

            var response = await client.SendAsync(httpRequest);
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_Should_Return_UnAuthorized()
        {
            var client = _factory.CreateClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "/api/discount/getDiscount");

            var response = await client.SendAsync(httpRequest);
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
