using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Easyourtour.Models
{
    public class HotelRoomImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int HotelRoomId { get; set; }

        [ForeignKey("HotelRoomId")]
        public HotelRoom HotelRoom { get; set; }
    }
}
