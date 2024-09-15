namespace Easyourtour.Models
{
    public class TemplateCost
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public decimal HotelCost { get; set; }

        public decimal TravelCost { get; set; }

        public decimal FinalCost { get; set; }
    }
}
