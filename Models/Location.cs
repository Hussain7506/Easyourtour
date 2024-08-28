using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easyourtour.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DestinationId { get; set; }
        [ForeignKey("DestinationId")]
        [ValidateNever]
        public Destination Destination { get; set; }
        [ValidateNever]
        public List<LocationImage> LocationImages { get; set; }
    }
}
