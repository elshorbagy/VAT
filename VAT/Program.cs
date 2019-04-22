using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VAT.Data;
using VAT.Service;

namespace VAT
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Working...");
            Settings.GetSettings();

            var service = BuildDependencies.Build();
            var data = await service.GetService<IExtractData>().GetHighestVatCountries(3);

            Console.Clear();
            Console.WriteLine("Hightest VAT Countries");

            PrintData(data);

            Console.WriteLine("------------------");
            Console.WriteLine("Lowest VAT Countries");

            data = await service.GetService<IExtractData>().GetLowestVatCountries(3);

            PrintData(data);
        }

        static void PrintData(List<VatData> vatDataList)
        {
            foreach (var vatData in vatDataList)
            {
                Console.WriteLine(vatData.Country + "\t" + vatData.VatStandard);
            }
        }
    }
}
