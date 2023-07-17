using System.ComponentModel.DataAnnotations;

namespace Api_Mine.Models.Data_Access
{
    public class PointDTO
    {
        [Required(ErrorMessage = "Поле Lat является обязательным.")]
        public double Lat { get; set; }
        [Required(ErrorMessage = "Поле Lng является обязательным.")]
        public double Lng { get; set; }
    }
}
