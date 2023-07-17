using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api_Mine.Models.API_Data_Model
{
    public class EditHoleDTO
    {
        [Required(ErrorMessage = "Поле Name является обязательным.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле DEPTH является обязательным.")]
        public double DEPTH { get; set; }

        [Required(ErrorMessage = "Поле DrillBlockId является обязательным.")]
        [JsonProperty(PropertyName = "DrillBlockId")]
        [System.Text.Json.Serialization.JsonPropertyName("DrillBlockId")]
        public int DrillBlockDatabaseModelId { get; set; }
    }
}
