using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Models.ViewModel
{
    public class SightseeingVm
    {
        public Sightseeing Sightseeing { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LocationList { get; set; }
    }
}
