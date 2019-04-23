using System.Collections.Generic;
using VAT;
using VAT.Data;
using VAT.Service;
using VAT.WebApi;
using Xunit;

namespace XUnitTestVat
{
    public class ExtractDataTest
    {
        private readonly IExtractData _extractData;

        public ExtractDataTest()
        {
            Settings.GetSettings();            
            _extractData =new ExtractData(new Restful());
        }

        [Fact]
        public async void GetLowestVatCountriesTest()
        {
            var vatData = await _extractData.GetLowestVatCountries(Settings.CountriesCount);
            Assert.IsType<List<VatData>>(vatData);
        }

        [Fact]
        public async void GetHighestVatCountriesTest()
        {
            var vatData = await _extractData.GetHighestVatCountries(Settings.CountriesCount);
            Assert.IsType<List<VatData>>(vatData);
        }

    }
}
