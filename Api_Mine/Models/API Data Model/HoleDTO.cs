using Api_Mine.Models.Data_Access;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Api_Mine.Models.API_Data_Model
{
    public class HoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DEPTH { get; set; }
        [JsonProperty(PropertyName = "DrillBlockId")]
        [System.Text.Json.Serialization.JsonPropertyName("DrillBlockId")]
        public int DrillBlockDatabaseModelId { get; set; }
    }
}
