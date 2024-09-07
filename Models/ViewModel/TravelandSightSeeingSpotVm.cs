namespace Easyourtour.Models.ViewModel
{
    public class TravelandSightSeeingSpotVm
    {
        public int TransportId { get; set; }
        public List<int> SightseeingIds { get; set; } = new List<int>();
        public double TotalCost { get; set; }
        public double? Kilometers { get; set; }
    }
}
