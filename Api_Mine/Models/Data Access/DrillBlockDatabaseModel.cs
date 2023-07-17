using System;

namespace Api_Mine.Models.Data_Access
{
    public class DrillBlockDatabaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Предполагается, что это поле отвечает за дату
        // когда были проведены работы на блоке обуривания 
        // а не дата обновления данных, так как не сказано иного. 
        public DateTime UpdateDate { get; set; }
    }
}
