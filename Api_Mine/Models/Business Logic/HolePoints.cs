using Api_Mine.Models.Data_Access;

namespace Api_Mine.Models.Business_Logic
{
    public class HolePoints
    {
        public int Id { get; set; }
        public int HoleId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
