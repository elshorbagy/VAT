using Microsoft.Extensions.DependencyInjection;
using VAT.Service;
using VAT.WebApi;

namespace VAT
{
    public static class BuildDependencies
    {
        public static ServiceProvider Build()
        {
            var services = new ServiceCollection()
                .AddTransient<IRestful, Restful>()
                .AddTransient<IExtractData, ExtractData>()
                .BuildServiceProvider();

            return services;
        }

    }
 }
