using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Models.ViewModel
{
    public class HotelRoomVm
    {
        public HotelRoom HotelRoom { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> HotelList { get; set; }
    }
}
