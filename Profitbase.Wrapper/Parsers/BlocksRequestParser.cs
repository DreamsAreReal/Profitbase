using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Profitbase.Wrapper.Enums;
using Profitbase.Wrapper.Models;

namespace Profitbase.Wrapper.Parsers
{
    class BlocksRequestParser
    {

        /// <summary>
        /// Returns blocks in section
        /// </summary>
        /// <param name="json">Answer from block request</param>
        /// <returns>Block models</returns>
        public List<BlockModel> GetBlocks(string json)
        {
            if (string.IsNullOrEmpty(json))
                return new List<BlockModel>();

            var blocks = new List<BlockModel>();

            if (JsonConvert.DeserializeObject(json) is JObject jsonObj)
            {
                if (jsonObj["response"]!=null)
                {
                    foreach (var project in jsonObj["response"])
                    {
                        if (project != null)
                        {
                            for (int i = 0; i < jsonObj?["response"]?["sections"].Children().Count(); i++)
                            {
                                if (jsonObj?["response"]?["sections"][i] != null)
                                {
                                    foreach (var floor in jsonObj?["response"]?["sections"][i]["floors"])
                                    {
                                        if (floor != null)
                                        {
                                            foreach (var block in floor["properties"])
                                            {
                                                string number;
                                                string address;
                                                string sectionName;
                                                string fullName;
                                                string projectName;
                                                string layoutUrl;
                                                string type;
                                                var status = BlockStatus.EMPTY;

                                                if (block["id"] != null
                                                && int.TryParse(block["id"].ToString(), out var id)
                                                && block["number"] != null
                                                && block["address"] != null
                                                && block["floor_number"] != null
                                                && int.TryParse(block["floor_number"].ToString(), out var floorNumber)
                                                && block["section_name"] != null
                                                && jsonObj?["response"]?["full_name"] != null
                                                && jsonObj?["response"]?["project_name"] != null
                                                && block["rooms"]!=null
                                                && int.TryParse(block["rooms"].ToString(), out var roomsCount)
                                                && block["area"] != null
                                                && double.TryParse(block["area"].ToString(), out var area)
                                                && block["price_meter"] != null
                                                && int.TryParse(block["price_meter"].ToString(), out var priceMeter)
                                                && block["price"] != null
                                                && int.TryParse(block["price"].ToString(), out var price)
                                                && block["property_type_name"] != null
                                                && block["apartment_status_key"] != null
                                                )
                                                {
                                                    number = block["number"]?.ToString();
                                                    address = block["address"].ToString();
                                                    sectionName = block["section_name"].ToString();
                                                    fullName = jsonObj?["response"]?["full_name"].ToString();
                                                    projectName = jsonObj?["response"]?["project_name"]?.ToString();
                                                    type = block["property_type_name"]?.ToString();

                                                    if (Enum.TryParse(block["apartment_status_key"].ToString(), out BlockStatus statusInService))
                                                    {
                                                        status = statusInService;
                                                    }


                                                }
                                                else
                                                {
                                                    continue;
                                                }

                                                try
                                                {
                                                    layoutUrl = block["layout"]?["url"].ToString();
                                                }
                                                catch
                                                {
                                                    layoutUrl = "";
                                                }

                                                blocks.Add(new BlockModel
                                                {
                                                    Id = id,
                                                    Number = number,
                                                    Address = address,
                                                    Level = floorNumber,
                                                    Section = sectionName,
                                                    BuildingName = fullName,
                                                    ResComplexName = projectName,
                                                    RoomsCount = roomsCount,
                                                    LayoutRef = layoutUrl,
                                                    Area = area,
                                                    Price = priceMeter,
                                                    PriceTotal = price,
                                                    Type = type,
                                                    Status = status
                                                });

                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            

            return blocks;
        }
    }
}
