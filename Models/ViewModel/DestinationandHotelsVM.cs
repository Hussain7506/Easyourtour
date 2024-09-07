namespace Easyourtour.Models.ViewModel
{
    public class DestinationandHotelsVM
    {
        public int OptionNumber { get; set; }
        public int Hotelcost { get; set; }
       

        public List<DayItineraryVM> Days { get; set; } = new List<DayItineraryVM>();
    }
    
}
