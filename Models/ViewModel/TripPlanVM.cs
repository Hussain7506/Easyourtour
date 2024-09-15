using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Easyourtour.Models.ViewModel
{
    public class TripPlanVM
    {
        [Required]
        public string TemplateName { get; set; }

        [Required]
        public int NumberOfAdults { get; set; }

        public int NumberOfKids { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        public string StarRatingPreference { get; set; }

        public List<HotelDestinationOptionVM> HotelDestinationOptions { get; set; } = new List<HotelDestinationOptionVM>();

        public List<TravelSightseeingOptionVM> TravelSightseeingOptions { get; set; } = new List<TravelSightseeingOptionVM>();
    }

    public class HotelDestinationOptionVM
    {

        public List<HotelDestinationDayVM> HotelDestinationDays { get; set; } = new List<HotelDestinationDayVM>();
    }

    public class HotelDestinationDayVM
    {
        public int DayNumber { get; set; }

        public int DestinationId { get; set; }

        public int LocationId { get; set; }

        public int HotelId { get; set; }

        public int HotelRoomId { get; set; }

        public int NumRooms { get; set; }

        public int ExtraBeds { get; set; }

        public int Capacity { get; set; } // Pulled from HotelRoom Model

        public string Inclusions { get; set; } // Pulled from HotelRoom Model
    }

    public class TravelSightseeingOptionVM
    {
        

        public List<TravelSightseeingDayVM> TravelSightseeingDays { get; set; } = new List<TravelSightseeingDayVM>();
    }

    public class TravelSightseeingDayVM
    {
        public int DayNumber { get; set; }

        public int CarTypeId { get; set; }

        public double BasePrice { get; set; } // Pulled from Transport table

        public int BaseDistance { get; set; } // Pulled from Transport table

        public int Kilometers { get; set; }

        public List<int> SightseeingSpotIds { get; set; } = new List<int>();

        public string Miscellaneous { get; set; }
    }
}
