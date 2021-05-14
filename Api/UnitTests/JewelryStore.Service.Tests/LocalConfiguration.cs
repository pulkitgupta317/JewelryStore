using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.Service.Tests
{
    public class LocalConfiguration
    {
        public static IConfiguration GetConfiguration()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"AuthenticationSetting:Issuer", "JewelryShop"},
                {"AuthenticationSetting:Audience", "JewelryShop"},
                {"AuthenticationSetting:SecretKey", "not_so_secret_key"}
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            return configuration;
        }
    }
}
