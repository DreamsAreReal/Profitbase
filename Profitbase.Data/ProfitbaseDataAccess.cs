using System.Collections.Generic;
using Profitbase.Wrapper;


namespace Profitbase.Data
{
    public static class ProfitbaseDataAccess
    {
        public static IEnumerable<ProfitbaseSection> GetAll()
        {
            Api api = new Api();
            api.GetAllAsync("", "").Wait();
            return new List<ProfitbaseSection>();
        }
    }
}