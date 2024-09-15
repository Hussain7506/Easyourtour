using System.Collections.Generic;

namespace Easyourtour.Models
{
    public class HotelDestinationOption
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

     

        // Each option contains multiple days
        public List<HotelDestinationDay> HotelDestinationDays { get; set; } = new List<HotelDestinationDay>();
    }

    public class HotelDestinationDay
    {
        public int Id { get; set; }

        public int DayNumber { get; set; }

        public int DestinationId { get; set; }

        public int LocationId { get; set; }

        public int HotelId { get; set; }

        public int HotelRoomId { get; set; }

        public int NumRooms { get; set; }

        public int ExtraBeds { get; set; }

        public int Capacity { get; set; } // Pulled from HotelRoom Model

        public string Inclusions { get; set; } // Pulled from HotelRoom Model

        // Navigation properties for easier querying
        public Destination Destination { get; set; }
        public Location Location { get; set; }
        public Hotel Hotel { get; set; }
        public HotelRoom HotelRoom { get; set; }
    }
}
