using Microsoft.Extensions.DependencyInjection;
using VAT.Service;
using VAT.WebApi;

namespace VAT
{
    public static class Dependencies
    {
        public static ServiceProvider Build()
        {
            var services = new ServiceCollection()
                .AddTransient<IRestful, Restful>()
                .AddTransient<IDataExtract, DataExtract>()
                .BuildServiceProvider();

            return services;
        }

    }
 }
