using System.Threading.Tasks;
using VAT.Data;

namespace VAT.WebApi
{
    public interface IRestful
    {
        Task<RawData> GetData();
    }
}
