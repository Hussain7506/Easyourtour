using System.ComponentModel.DataAnnotations.Schema;

namespace Easyourtour.Models
{
    public class TravelandSightSeeingSpot
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        [ForeignKey("TemplateId")]
        public Template Template { get; set; }
        public int? TransportId { get; set; }
        [ForeignKey("TransportId")]
        public Transport Transport { get; set; }
        public List<DayItinerarySightseeing> DayItinerarySightseeings { get; set; }
        public double TotalCost { get; set; }
        public double? Kilometers { get; set; }
    }
}
