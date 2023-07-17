namespace Api_Mine.Models.Business_Logic
{
    public class DrillBlock
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Предполагается, что это поле отвечает за дату
        // когда были проведены работы на блоке обуривания 
        // а не дата обновления данных, так как не сказано иного. 
        public DateTime UpdateDate { get; set; }
    }
}
