using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Models.ViewModel
{
    public class LocationVm
    {
        public Location Location { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DestinationList { get; set; }
    }
}
