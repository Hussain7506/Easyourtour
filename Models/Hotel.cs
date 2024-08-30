using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easyourtour.Models
{
    public class Hotel
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public int Rating{ get; set; }
        public string Amenities { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        public Location Location { get; set; }
        [ValidateNever]
        public List<HotelImage> HotelImages { get; set; }
    }
}
