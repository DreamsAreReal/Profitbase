using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profitbase.Wrapper
{
    internal interface IClient
    {
        Task<string> ExecuteGetRequest(string address);
        Task<string> ExecutePostRequest(string address, Dictionary<string, string> parameters);
    }
}
