using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAT.Data;
using VAT.WebApi;

namespace VAT.Service
{
    public class ExtractData: IExtractData
    {
        private readonly IRestful _restful;
        private static RawData _rawData;

        public ExtractData(IRestful restful)
        {
            _restful = restful;
        }
        public async Task<List<VatData>> GetLowestVatCountries(int countriesCount)
        {
            var vatDataList =await GetRate();
            vatDataList=vatDataList.OrderBy(x => x.VatStandard).Take(countriesCount).ToList();

            return vatDataList;
        }

        public async Task<List<VatData>> GetHighestVatCountries(int countriesCount)
        {
            var vatDataList =await GetRate();
            vatDataList = vatDataList.OrderByDescending(x => x.VatStandard).Take(countriesCount).ToList();

            return vatDataList;
        }

        private async Task<List<VatData>> GetRate()
        {
            if (_rawData == null)
                _rawData = await _restful.GetData();

            var vatDataList = new List<VatData>(); 
            
            foreach (var rawDataRate in _rawData.Rates)
            {
                var vatData = new VatData
                {
                    Country = rawDataRate.Name
                };

                foreach (var ratePeriod in rawDataRate.Periods)
                {
                    vatData.VatStandard = ratePeriod.Rates.Standard;
                }
                vatDataList.Add(vatData);
            }

            return vatDataList;
        }
    }
}
