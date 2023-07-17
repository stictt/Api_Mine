using Api_Mine.Models.Data_Access;
using System.ComponentModel.DataAnnotations;

namespace Api_Mine.Models.API_Data_Model
{
    public class EditDrillBlockPointsDTO
    {
        [Required(ErrorMessage = "Поле DrillBlockId является обязательным.")]
        public int DrillBlockId { get; set; }

        // Предполагается, что это последовательность широты и долготы
        // которая отвечает за обозначение территории. 
        [Required(ErrorMessage = "Поле Sequence является обязательным.")]
        public List<PointDTO> Sequence { get; set; }

        [Required(ErrorMessage = "Поле X является обязательным.")]
        public double X { get; set; }

        [Required(ErrorMessage = "Поле Y является обязательным.")]
        public double Y { get; set; }

        [Required(ErrorMessage = "Поле Z является обязательным.")]
        public double Z { get; set; }
    }
}
