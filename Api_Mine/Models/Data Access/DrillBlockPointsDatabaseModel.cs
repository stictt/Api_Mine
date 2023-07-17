namespace Api_Mine.Models.Data_Access
{
    public class DrillBlockPointsDatabaseModel
    {
        public int Id { get; set; }
        public int DrillBlockId { get; set; }
        public DrillBlockDatabaseModel DrillBlockDatabaseModel { get; set; }

        // Предполагается, что это последовательность широты и долготы
        // которая отвечает за обозначение территории. 
        public List<PointDatabaseModel> Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
