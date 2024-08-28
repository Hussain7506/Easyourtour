using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Easyourtour.Models
{
    public class LocationImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
