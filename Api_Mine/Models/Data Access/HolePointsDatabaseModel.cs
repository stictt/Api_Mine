namespace Api_Mine.Models.Data_Access
{
    public class HolePointsDatabaseModel
    {
        public int Id { get; set; }
        public int HoleId { get; set; }
        public HoleDatabaseModel HoleDatabaseModel { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
