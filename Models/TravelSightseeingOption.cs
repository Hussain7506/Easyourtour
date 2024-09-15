using System.Collections.Generic;

namespace Easyourtour.Models
{
    public class TravelSightseeingOption
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

       

        // Each option contains multiple days of travel and sightseeing
        public List<TravelSightseeingDay> TravelSightseeingDays { get; set; } = new List<TravelSightseeingDay>();
    }

    public class TravelSightseeingDay
    {
        public int Id { get; set; }

        public int DayNumber { get; set; }

        public int CarTypeId { get; set; }

        public double BasePrice { get; set; } // Pulled from Transport table

        public int BaseDistance { get; set; } // Pulled from Transport table

        public int Kilometers { get; set; }

        public List<int> SightseeingSpotIds { get; set; } = new List<int>(); // List of Sightseeing spots visited

        public string Miscellaneous { get; set; }

        // Navigation properties
        public Transport CarType { get; set; }
        public List<Sightseeing> SightseeingSpots { get; set; } = new List<Sightseeing>();
    }
}
