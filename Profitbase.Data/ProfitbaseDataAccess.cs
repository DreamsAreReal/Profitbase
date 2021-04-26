using System.Collections.Generic;
using Profitbase.Wrapper;


namespace Profitbase.Data
{
    public static class ProfitbaseDataAccess
    {
        public static IEnumerable<ProfitbaseSection> GetAll()
        {
            Api api = new Api();
            api.GetAll("", "");
            return new List<ProfitbaseSection>();
        }
    }
}