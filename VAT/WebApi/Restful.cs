using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VAT.Data;

namespace VAT.WebApi
{
    public class Restful: IRestful
    {      
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
                var response = await client.DownloadStringTaskAsync(Settings.Url);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw ;
            }
        }
    }
}
