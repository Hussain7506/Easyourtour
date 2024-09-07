namespace Easyourtour.Models.ViewModel
{
    public class TripPlanVM
    {
        public string TemplateName { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public List<DestinationandHotelsVM> DestinationandHotels { get; set; } = new List<DestinationandHotelsVM>();
        public List<TravelandSightSeeingSpotVm> TravelandSightSeeingSpots { get; set; } = new List<TravelandSightSeeingSpotVm>();
        public double FinalCost { get; set; }
        public string StarRatingPreference { get; set; }
    }
}
