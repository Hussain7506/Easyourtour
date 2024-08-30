using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easyourtour.Models
{
    public class Transport
    {
        public int Id {  get; set; }
        public string CarType { get; set; }
        public int CarCap { get; set; }
        public int BaseDistance { get; set; }
        public double BasePrice { get; set; }
        public double PricePerKm { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        public Location Location { get; set; }
        
    }
}
