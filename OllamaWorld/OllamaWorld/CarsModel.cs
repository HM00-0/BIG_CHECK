using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OllamaWorld
{
    public class CarsModel
    {
        
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("car_number")]
        public int car_number { get; set; }

        [JsonPropertyName("is_in")]
        public bool IsIn { get; set; }

        [JsonPropertyName("place_number")]
        public int place_number { get; set; }

        [JsonPropertyName("place_sector")]
        public char place_sector { get; set; }
    }
}