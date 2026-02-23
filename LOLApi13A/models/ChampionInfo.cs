using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LOLApi13A.models
{
    public class ChampionInfo
    {
        [JsonPropertyName("attack")]
        public int Attack { get; set; }

        [JsonPropertyName("defense")]
        public int Defense { get; set; }

        [JsonPropertyName("magic")]
        public int Magic { get; set; }

        [JsonPropertyName("difficulty")]
        public int Difficulty { get; set; }

    }
}
