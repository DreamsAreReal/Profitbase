using System.Threading.Tasks;

namespace Profitbase.Wrapper
{
    internal interface IClient
    {
        Task<string> ExecuteGetRequest(string address);
    }
}
