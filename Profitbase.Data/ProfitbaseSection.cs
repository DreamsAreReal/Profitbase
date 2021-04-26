using System.Collections.Generic;

namespace Profitbase.Data
{
    public class ProfitbaseSection
    {
        public string Name { get; set; }

        public IEnumerable<ProfitbaseBlock> Blocks { get; set; }
    }
}