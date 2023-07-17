namespace Api_Mine.Models.Data_Access
{
    public class PointDatabaseModel
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DrillBlockPointsDatabaseModel DrillBlockPointsDatabaseModel { get; set; }
        public int DrillBlockPointsDatabaseModelId { get; set; }
    }
}
