using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAT.Data;
using VAT.WebApi;

namespace VAT.Service
{
    public class DataExtract: IDataExtract
    {
        private readonly IRestful _restful;        

        public DataExtract(IRestful restful)
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
            var rawData = new RawData();

            rawData = await GetDataFromRestful(rawData);

            var vatDataList = new List<VatData>();

            foreach (var rawDataRate in rawData.Rates)
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

        private async Task<RawData> GetDataFromRestful(RawData rawData)
        {
            if (rawData == null) throw new ArgumentNullException(nameof(rawData));

            if (CacheData.CachedRawData == null)
            {
                rawData = await _restful.GetData();
                CacheData.CachedRawData = rawData;
            }
            else
            {
                rawData = CacheData.CachedRawData;
            }

            return rawData;
        }
    }
}