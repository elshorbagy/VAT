using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace VAT
{
    public static class Settings
    {        
        public static string Url { get; set; }
        public static int CountriesCount { get; set; }

        public static void GetSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            Url=config.GetSection("url").GetSection("vat").Value;
            CountriesCount=Convert.ToInt32(config.GetSection("countries").GetSection("count").Value);
        }
    }
}
