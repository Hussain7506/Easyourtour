using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easyourtour.Models
{
    public class HotelRoom
    {
        [Key]
        public int Id { get; set; }
        public string RoomType { get; set; }
        public double priceonseason { get; set; }
        public double priceoffseason { get; set; }
        public int capacity { get; set; }
        public double extrachargeperperson { get; set; }
        public string Inclusions { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        [ValidateNever]
        public Hotel Hotel { get; set; }
        [ValidateNever]
        public List<HotelRoomImage> HotelRoomImages { get; set; }

    }
}
