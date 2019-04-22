using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VAT.Data;

namespace VAT.WebApi
{
    public class Restful: IRestful
    {
        private readonly string _url;

        public Restful()
        {
           _url= Settings.Url;
        }

        public async Task<RawData> GetData()
        {            
            var response =await ConnectToRestful();            
            return JsonConvert.DeserializeObject<RawData>(response);
        }

        private async Task<string> ConnectToRestful()
        {
            try
            {
                var client = new WebClient();
                var response = await client.DownloadStringTaskAsync(_url);
                return response.Replace("0000-01-01", "1900-01-01");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw ;
            }
        }
    }
}
