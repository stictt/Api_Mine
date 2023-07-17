using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Mine.Models.Data_Access
{
    public class HoleDatabaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DEPTH { get; set; }
        public DrillBlockDatabaseModel DrillBlockDatabaseModel { get; set; }
        public int DrillBlockDatabaseModelId { get; set; }
    }
}   
