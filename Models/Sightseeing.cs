using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Easyourtour.Models
{
    public class Sightseeing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double EntryFee { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        [ValidateNever]
        public Location Location { get; set; }
        [ValidateNever]
        public List<SightseeingImage> SightseeingImages { get; set; }
    }
}
