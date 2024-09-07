using System.ComponentModel.DataAnnotations;

namespace Easyourtour.Models
{
    public class Template
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TemplateName { get; set; }

        [Required]
        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        public double FinalCost { get; set; }

        // Navigation Property
        //public List<DayItinerary> DayItineraries { get; set; }
        public List<DestinationandHotels> DestinationandHotel { get; set; }
        public List<TravelandSightSeeingSpot> travelandSightSeeingSpots { get; set; } 
        public string StarRatingPreference { get; set; }
    }
}
