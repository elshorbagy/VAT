using System.Collections.Generic;
using VAT;
using VAT.Data;
using VAT.Service;
using VAT.WebApi;
using Xunit;

namespace XUnitTestVat
{
    public class DataExtractTest
    {
        private readonly IDataExtract _extractData;

        public DataExtractTest()
        {
            Settings.GetSettings();            
            _extractData =new DataExtract(new Restful());
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
