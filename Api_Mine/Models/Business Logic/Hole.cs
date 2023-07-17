using Api_Mine.Models.Data_Access;

namespace Api_Mine.Models.Business_Logic
{
    public class Hole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DEPTH { get; set; }
        public int DrillBlockDatabaseModelId { get; set; }
    }
}
