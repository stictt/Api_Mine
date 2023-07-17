using System.ComponentModel.DataAnnotations;

namespace Api_Mine.Models.API_Data_Model
{
    public class EditDrillBlockDTO
    {
        [Required(ErrorMessage = "Поле Name является обязательным.")]
        public string Name { get; set; }

        // Предполагается, что это поле отвечает за дату
        // когда были проведены работы на блоке обуривания 
        // а не дата обновления данных, так как не сказано иного. 
        [Required(ErrorMessage = "Поле UpdateDate является обязательным.")]
        public DateTime UpdateDate { get; set; }
    }
}
