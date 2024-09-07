using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easyourtour.Models
{
    public class DayItinerarySightseeing
    {
        [Key, Column(Order = 1)]
        public int DayItineraryId { get; set; }

        [Key, Column(Order = 2)]
        public int SightseeingId { get; set; }

        [ForeignKey("DayItineraryId")]
        public DayItinerary DayItinerary { get; set; }

        [ForeignKey("SightseeingId")]
        public Sightseeing Sightseeing { get; set; }
    }
}
