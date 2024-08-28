using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Models.ViewModel
{
    public class HotelVm
    {
        public Hotel Hotel { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LocationList { get; set; }
    }
}
