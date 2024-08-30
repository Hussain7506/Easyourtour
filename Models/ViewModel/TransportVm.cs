using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Models.ViewModel
{
    public class TransportVm
    {
        public Transport Transport  { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LocationList { get; set; }
    }
}
