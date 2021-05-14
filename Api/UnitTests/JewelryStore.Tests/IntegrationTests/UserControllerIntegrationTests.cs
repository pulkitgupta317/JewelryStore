using JewelryStore.Services.Dtos;
using JewerlyStore;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JewelryStore.Tests.IntegrationTests
{
    public class UserControllerIntegrationTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UserControllerIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Post_Should_Return_OkResponse()
        {
            var client = _factory.CreateClient();
            AuthRequestDto authRequestDto = new AuthRequestDto()
            {
                Password = "Temppass@123",
                UserName = "Mathew"
            };
            string obj = JsonConvert.SerializeObject(authRequestDto);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/user/authenticate")
            {
                Content = new StringContent(obj, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(httpRequest);
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_Should_Return_BadResponse()
        {
            var client = _factory.CreateClient();
            AuthRequestDto authRequestDto = new AuthRequestDto()
            {
                Password = "Temppass",
                UserName = "Mathew"
            };
            string obj = JsonConvert.SerializeObject(authRequestDto);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/user/authenticate")
            {
                Content = new StringContent(obj, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(httpRequest);
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Post_Should_Return_UnAuthorized()
        {
            var client = _factory.CreateClient();
            AuthRequestDto authRequestDto = new AuthRequestDto()
            {
                Password = "Temppass@12",
                UserName = "Mathew"
            };
            string obj = JsonConvert.SerializeObject(authRequestDto);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/user/authenticate")
            {
                Content = new StringContent(obj, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(httpRequest);
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
