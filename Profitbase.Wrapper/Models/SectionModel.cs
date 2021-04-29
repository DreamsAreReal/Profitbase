using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profitbase.Wrapper.Models
{
    class SectionModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<BlockModel> Blocks { get; set; }
    }
}
