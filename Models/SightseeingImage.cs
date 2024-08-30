using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Easyourtour.Models
{
    public class SightseeingImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int SightseeingId { get; set; }

        [ForeignKey("HotelId")]
        public Sightseeing Sightseeing { get; set; }
    }
}
