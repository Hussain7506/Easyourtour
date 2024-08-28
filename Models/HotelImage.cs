using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Easyourtour.Models
{
    public class HotelImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Location Hotel { get; set; }
    }
}
