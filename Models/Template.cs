using System;
using System.Collections.Generic;
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
        public double commission { get; set; }

        public string StarRatingPreference { get; set; }

        // List of Hotel and Destination options
        public List<HotelDestinationOption> HotelDestinationOptions { get; set; } = new List<HotelDestinationOption>();

        // List of Travel and Sightseeing options
        public List<TravelSightseeingOption> TravelSightseeingOptions { get; set; } = new List<TravelSightseeingOption>();

        // Costs for each option
        public List<TemplateCost> TemplateCosts { get; set; } = new List<TemplateCost>();
    }
}
