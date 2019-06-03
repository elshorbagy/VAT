using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VAT.Data;
using VAT.Service;

namespace VAT
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Working...");
            Settings.GetSettings();
            
            var service = Dependencies.Build();
            var extractData = service.GetService<IDataExtract>();

            var data = await extractData.GetHighestVatCountries(Settings.CountriesCount);

            Console.Clear();
            Console.WriteLine("Hightest VAT Countries");

            PrintData(data);

            Console.WriteLine("------------------");
            Console.WriteLine("Lowest VAT Countries");

            data = await extractData.GetLowestVatCountries(Settings.CountriesCount);

            PrintData(data);

            Console.Read();
        }

        private static void PrintData(List<VatData> vatDataList)
        {
            foreach (var vatData in vatDataList)
            {
                Console.WriteLine(vatData.Country + "\t" + vatData.VatStandard);
            }
        }
    }
}
