namespace Easyourtour.Models
{
    public class DestinationandHotels
    {
        public int Id { get; set; }
        public int OptionNumber { get; set; }
        public List<DayItinerary> DayItineraries { get; set; }
        public double HotelCost { get; set; }
    }
}
