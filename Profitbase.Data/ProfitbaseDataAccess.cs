using System.Collections.Generic;
using Profitbase.Wrapper;
using Profitbase.Wrapper.Enums;
using Profitbase.Wrapper.Models;


namespace Profitbase.Data
{
    public static class ProfitbaseDataAccess
    {
        public static IEnumerable<ProfitbaseSection> GetAll(string login, string password)
        {
            return new Api().GetAllAsync(login, password).Result.ConvertSectionModels();
        }


        /// <summary>
        /// This method need to convert models in wrapper to data models
        /// </summary>
        /// <param name="models">Models from wrapper</param>
        /// <returns>Models in data</returns>
        private static List<ProfitbaseSection> ConvertSectionModels(this List<SectionModel> models)
        {
            List<ProfitbaseSection> sections = new List<ProfitbaseSection>();

            foreach (var model in models)
            {
                List<ProfitbaseBlock> pBlocks = new List<ProfitbaseBlock>();
                foreach (var block in model.Blocks)
                {
                    ProfitbaseBlockStatus status = ProfitbaseBlockStatus.Empty;
                    switch (block.Status)
                    {
                        case BlockStatus.BOOKED:
                            status = ProfitbaseBlockStatus.Blocked;
                            break;
                        case BlockStatus.AVAILABLE:
                            status = ProfitbaseBlockStatus.InStock;
                            break;
                        case BlockStatus.SOLD:
                            status = ProfitbaseBlockStatus.Sealed;
                            break;
                        

                    }    

                   pBlocks.Add(new ProfitbaseBlock()
                   {
                       Address = block.Address,
                       Area =  block.Area,
                       BuildingName = block.BuildingName,
                       Id = block.Id,
                       LayoutCode = block.LayoutCode,
                       LayoutRef = block.LayoutRef,
                       Level = block.Level,
                       Number = block.Number,
                       Price = block.Price,
                       PriceTotal = block.PriceTotal,
                       Section = block.Section,
                       ResComplexName = block.ResComplexName,
                       RoomsCount = block.RoomsCount,
                       Type = block.Type,
                       Status = status
                   });
                } 
                
                sections.Add(new ProfitbaseSection()
                {
                    Blocks = pBlocks,
                    Name = model.Name
                });
            }


            return sections;
        }
    }
}