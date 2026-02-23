using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LOLApi13A.models
{
    public class ChampionData
    {
        [JsonPropertyName("data")]
        public Dictionary<string, Champion> Data { get; set; }
    }
}
