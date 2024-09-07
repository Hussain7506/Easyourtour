using Easyourtour.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class DayItinerary
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int DayNumber { get; set; }

    // Foreign Key to Template
    public int TemplateId { get; set; }
    [ForeignKey("TemplateId")]
    public Template Template { get; set; }

    // Foreign Keys to other entities (nullable)
    public int? DestinationId { get; set; }
    [ForeignKey("DestinationId")]
    public Destination Destination { get; set; }

    public int? LocationId { get; set; }
    [ForeignKey("LocationId")]
    public Location Location { get; set; }

    public int? HotelId { get; set; }
    [ForeignKey("HotelId")]
    public Hotel Hotel { get; set; }

    public int? HotelRoomId { get; set; }
    [ForeignKey("HotelRoomId")]
    public HotelRoom HotelRoom { get; set; }

   
    public List<DayItineraryRoom> DayItineraryRooms { get; set; } = new List<DayItineraryRoom>();

    
}
public class DayItineraryRoom
{
    public int Id { get; set; }
    public int DayItineraryId { get; set; }
    public int HotelRoomId { get; set; }
    public int NumberOfRooms { get; set; }
    public int ExtraPersons { get; set; }
    public double TotalRoomCost { get; set; }

    public DayItinerary DayItinerary { get; set; }
    public HotelRoom HotelRoom { get; set; }
}