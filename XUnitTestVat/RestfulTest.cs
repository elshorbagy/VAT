using System.Threading.Tasks;
using VAT;
using VAT.Data;
using VAT.WebApi;
using Xunit;

namespace XUnitTestVat
{
    public class RestfulTest
    {
        private readonly IRestful _iRestful;
        
        public RestfulTest()
        {
            Settings.GetSettings();
            _iRestful=new Restful();
        }

        [Fact]
        public async Task GetDataTestAsync()
        {
           var rawData= await _iRestful.GetData();

            Assert.IsType<RawData>(rawData);
        }
    }
}
