using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OllamaWorld
{
    public class MaterialsModel
    {
        
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("is_arrived")]
        public bool IsArrived { get; set; }

        [JsonPropertyName("is_used")]
        public bool IsUsed { get; set; }

        [JsonPropertyName("place_sector")]
        public char Place_sector { get; set; }
    }
}