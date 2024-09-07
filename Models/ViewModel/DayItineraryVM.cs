namespace Easyourtour.Models.ViewModel
{
    public class DayItineraryVM
    {
        public int DayNumber { get; set; }
        public int DestinationId { get; set; }
        public int LocationId { get; set; }
        public int HotelId { get; set; }
        public int HotelRoomId { get; set; }

        public List<DayItineraryRoomVM> Rooms { get; set; } = new List<DayItineraryRoomVM>();
    }
}
