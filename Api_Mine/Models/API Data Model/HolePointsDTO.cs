using Api_Mine.Models.Data_Access;

namespace Api_Mine.Models.API_Data_Model
{
    public class HolePointsDTO
    {
        public int Id { get; set; }
        public int HoleId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
