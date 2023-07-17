using System.ComponentModel.DataAnnotations;

namespace Api_Mine.Models.API_Data_Model
{
    public class EditHolePointsDTO
    {
        [Required(ErrorMessage = "Поле HoleId является обязательным.")]
        public int HoleId { get; set; }

        [Required(ErrorMessage = "Поле X является обязательным.")]
        public double X { get; set; }

        [Required(ErrorMessage = "Поле Y является обязательным.")]
        public double Y { get; set; }

        [Required(ErrorMessage = "Поле Z является обязательным.")]
        public double Z { get; set; }
    }
}
