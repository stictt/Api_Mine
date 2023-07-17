using Api_Mine.Models.Data_Access;

namespace Api_Mine.Models.API_Data_Model
{
    public class DrillBlockPointsDTO
    {
        public int Id { get; set; }
        public int DrillBlockId { get; set; }

        // Предполагается, что это последовательность широты и долготы
        // которая отвечает за обозначение территории. 
        public List<PointDTO> Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
