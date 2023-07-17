namespace Api_Mine.Models.Business_Logic
{
    public class DrillBlockPoints
    {
        public int Id { get; set; }
        public int DrillBlockId { get; set; }

        // Предполагается, что это последовательность широты и долготы
        // которая отвечает за обозначение территории. 
        public List<Point> Sequence { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
