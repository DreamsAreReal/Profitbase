using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Profitbase.Wrapper.Models;

namespace Profitbase.Wrapper.Parsers
{
    class ProjectsRequestParser
    {

        /// <summary>
        /// Get sections
        /// </summary>
        /// <param name="json">Answer from project request</param>
        /// <returns>Sections</returns>
        public List<SectionModel> GetHouses(string json)
        {
            if(string.IsNullOrEmpty(json))
                return new List<SectionModel>();

            var sections = new List<SectionModel>();

            if (JsonConvert.DeserializeObject(json) is JObject jsonObj)
            {
                foreach (var project in jsonObj?["response"])
                {
                    if (project != null)
                    {
                        foreach (var house in project?["houses"])
                        {
                            sections.Add(new SectionModel
                            {
                                Id = house["id"]?.ToString(),
                                Name = house["full_name"]?.ToString(),
                            });
                        }
                    }

                }
            }

            return sections;
        }
    }
}
