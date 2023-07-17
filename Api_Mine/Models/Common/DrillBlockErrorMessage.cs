namespace Api_Mine.Models.Common
{
    public class DrillBlockErrorMessage
    {
        public string Message { get; set; }
        public List<int> HolesId { get; set; }
        public List<int> DrillBlockPointsId { get; set; }
    }
}
