using Easyourtour.Data;
using Easyourtour.Models.ViewModel;
using Easyourtour.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Easyourtour.Controllers
{
    public class TripPlannerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripPlannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var templates = await _context.Templates.ToListAsync();
            return View(templates);
        }

        // GET: Create Template
        public IActionResult CreateTemplate()
        {
            var model = new TripPlanVM();
            PopulateDropdowns(model);
            return View(model);
        }

        // POST: Save the template and related options
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTemplate(TripPlanVM model)
        {
            if (ModelState.IsValid)
            {
                var template = new Template
                {
                    TemplateName = model.TemplateName,
                    NumberOfAdults = model.NumberOfAdults,
                    NumberOfKids = model.NumberOfKids,
                    StartDate = model.StartDate,
                    NumberOfDays = model.NumberOfDays,
                    StarRatingPreference = model.StarRatingPreference,
                    commission= model.commission
                };

                // Add HotelDestinationOptions
                foreach (var option in model.HotelDestinationOptions)
                {
                    var hotelDestinationOption = new HotelDestinationOption
                    {

                    };

                    foreach (var day in option.HotelDestinationDays)
                    {
                        hotelDestinationOption.HotelDestinationDays.Add(new HotelDestinationDay
                        {
                            DayNumber = day.DayNumber,
                            DestinationId = day.DestinationId,
                            LocationId = day.LocationId,
                            HotelId = day.HotelId,
                            HotelRoomId = day.HotelRoomId,
                            NumRooms = day.NumRooms,
                            ExtraBeds = day.ExtraBeds,
                            Capacity = day.Capacity,
                            Inclusions = day.Inclusions
                        });
                    }

                    template.HotelDestinationOptions.Add(hotelDestinationOption);
                }

                // Add TravelSightseeingOptions
                foreach (var travelOption in model.TravelSightseeingOptions)
                {
                    var travelSightseeingOption = new TravelSightseeingOption
                    {

                    };

                    foreach (var travelDay in travelOption.TravelSightseeingDays)
                    {
                        travelSightseeingOption.TravelSightseeingDays.Add(new TravelSightseeingDay
                        {
                            DayNumber = travelDay.DayNumber,
                            CarTypeId = travelDay.CarTypeId,
                            BasePrice = travelDay.BasePrice,
                            BaseDistance = travelDay.BaseDistance,
                            Kilometers = travelDay.Kilometers,
                            SightseeingSpotIds = travelDay.SightseeingSpotIds,
                            Miscellaneous = travelDay.Miscellaneous
                        });
                    }

                    template.TravelSightseeingOptions.Add(travelSightseeingOption);
                }

                // Save template
                _context.Templates.Add(template);
                await _context.SaveChangesAsync();

                return RedirectToAction("CalculateCost", new { templateId = template.Id });
            }

            return View(model);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            var template = await _context.Templates
                .Include(t => t.HotelDestinationOptions)
                    .ThenInclude(hdo => hdo.HotelDestinationDays)
                .Include(t => t.TravelSightseeingOptions)
                    .ThenInclude(tso => tso.TravelSightseeingDays)
                        .ThenInclude(tsd => tsd.SightseeingSpots) // Load nested SightseeingSpots
                .FirstOrDefaultAsync(t => t.Id == id);

            if (template == null)
            {
                return Json(new { success = false, message = "Template not found." });
            }

            // 1. Remove related HotelDestinationOptions, HotelDestinationDays, and any nested entities
            foreach (var hotelOption in template.HotelDestinationOptions.ToList())
            {
                // First, remove the HotelDestinationDays
                foreach (var hotelDay in hotelOption.HotelDestinationDays.ToList())
                {
                    _context.HotelDestinationDays.Remove(hotelDay);
                }

                // Then, remove the HotelDestinationOption
                _context.HotelDestinationOptions.Remove(hotelOption);
            }

            // 2. Remove related TravelSightseeingOptions, TravelSightseeingDays, and nested SightseeingSpots
            foreach (var travelOption in template.TravelSightseeingOptions.ToList())
            {
                foreach (var travelDay in travelOption.TravelSightseeingDays.ToList())
                {
                    // First, remove the related SightseeingSpots for each day
                    travelDay.SightseeingSpots.Clear(); // Clear or remove each related sightseeing spot if it's tracked

                    // Then, remove the TravelSightseeingDay
                    _context.TravelSightseeingDays.Remove(travelDay);
                }

                // Remove the TravelSightseeingOption
                _context.TravelSightseeingOptions.Remove(travelOption);
            }

            // 3. Finally, remove the template itself
            _context.Templates.Remove(template);

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Template and related options deleted successfully." });
        }

        // GET: Calculate cost for each option
        public async Task<IActionResult> CalculateCost(int templateId)
        {
            var template = await _context.Templates
                .Include(t => t.HotelDestinationOptions)
                .ThenInclude(h => h.HotelDestinationDays)
                .Include(t => t.TravelSightseeingOptions)
                .ThenInclude(t => t.TravelSightseeingDays)
                 .ThenInclude(tsd => tsd.CarType)
                .FirstOrDefaultAsync(t => t.Id == templateId);

            if (template == null)
            {
                return NotFound();
            }
            
            // Calculate costs for each option and save in TemplateCost
            foreach (var hotelOption in template.HotelDestinationOptions)
            {
                decimal hotelCost = 0;
                
                    foreach (var day in hotelOption.HotelDestinationDays)
                {

                    var room = await _context.HotelRooms.FindAsync(day.HotelRoomId);
                    if ((template.StartDate.Month > room.StartDate.Month ||
                (template.StartDate.Month == room.StartDate.Month && template.StartDate.Day >= room.StartDate.Day)) &&
               (template.StartDate.Month < room.EndDate.Month ||
                (template.StartDate.Month == room.EndDate.Month && template.StartDate.Day <= room.EndDate.Day)))
                    {
                        hotelCost += (day.NumRooms * (decimal)room.priceonseason) + (day.ExtraBeds * (decimal)room.extrachargeperperson);
                    }

                    else
                    {
                        hotelCost += (day.NumRooms * (decimal)room.priceoffseason) + (day.ExtraBeds * (decimal)room.extrachargeperperson);
                    }
                       
                }

                foreach (var travelOption in template.TravelSightseeingOptions)
                {
                    decimal travelCost = 0;

                    foreach (var travelDay in travelOption.TravelSightseeingDays)
                    {
                        // Convert double to decimal for travel calculations
                        travelCost += (decimal)travelDay.BasePrice;
                        travelCost += (decimal)travelDay.Miscellaneous;

                        if (travelDay.Kilometers > travelDay.BaseDistance)
                        {
                            travelCost += (travelDay.Kilometers - travelDay.BaseDistance) * (decimal)travelDay.CarType.PricePerKm;
                        }
                    }

                    // Add the calculated costs to the TemplateCosts
                    template.TemplateCosts.Add(new TemplateCost
                    {
                        HotelCost = hotelCost,
                        TravelCost = travelCost,
                        FinalCost = hotelCost + travelCost+(decimal)template.commission
                    });
                }
            }

            await _context.SaveChangesAsync();

            return View(template.TemplateCosts); // Return the calculated costs to a view
        }

        // GET: Edit Template
        

        // POST: Edit Template
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTemplate(int id, TripPlanVM model)
        {
            if (ModelState.IsValid)
            {
                var template = await _context.Templates
                    .Include(t => t.HotelDestinationOptions)
                    .ThenInclude(h => h.HotelDestinationDays)
                    .Include(t => t.TravelSightseeingOptions)
                    .ThenInclude(t => t.TravelSightseeingDays)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (template == null)
                {
                    return NotFound();
                }

                // Update the template with new values
                template.TemplateName = model.TemplateName;
                template.NumberOfAdults = model.NumberOfAdults;
                template.NumberOfKids = model.NumberOfKids;
                template.StartDate = model.StartDate;
                template.NumberOfDays = model.NumberOfDays;
                template.StarRatingPreference = model.StarRatingPreference;
                template.commission = model.commission;

                // Clear existing options
                _context.HotelDestinationOptions.RemoveRange(template.HotelDestinationOptions);
                _context.TravelSightseeingOptions.RemoveRange(template.TravelSightseeingOptions);

                // Add updated HotelDestinationOptions
                foreach (var option in model.HotelDestinationOptions)
                {
                    var hotelDestinationOption = new HotelDestinationOption
                    {
                        HotelDestinationDays = option.HotelDestinationDays.Select(d => new HotelDestinationDay
                        {
                            DayNumber = d.DayNumber,
                            DestinationId = d.DestinationId,
                            LocationId = d.LocationId,
                            HotelId = d.HotelId,
                            HotelRoomId = d.HotelRoomId,
                            NumRooms = d.NumRooms,
                            ExtraBeds = d.ExtraBeds,
                            Capacity = d.Capacity,
                            Inclusions = d.Inclusions
                        }).ToList()
                    };

                    template.HotelDestinationOptions.Add(hotelDestinationOption);
                }

                // Add updated TravelSightseeingOptions
                foreach (var travelOption in model.TravelSightseeingOptions)
                {
                    var travelSightseeingOption = new TravelSightseeingOption
                    {
                        TravelSightseeingDays = travelOption.TravelSightseeingDays.Select(td => new TravelSightseeingDay
                        {
                            DayNumber = td.DayNumber,
                            CarTypeId = td.CarTypeId,
                            BasePrice = td.BasePrice,
                            BaseDistance = td.BaseDistance,
                            Kilometers = td.Kilometers,
                            SightseeingSpotIds = td.SightseeingSpotIds,
                            Miscellaneous = td.Miscellaneous
                        }).ToList()
                    };

                    template.TravelSightseeingOptions.Add(travelSightseeingOption);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            PopulateDropdowns(model);
            return View(model);
        }

        private void PopulateDropdowns(TripPlanVM model)
        {
            ViewBag.Destinations = _context.Destinations.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

        }

        [HttpGet("TripPlanner/GetLocations/{destinationId}")]
        public JsonResult GetLocations(int destinationId)
        {
            var locations = _context.Locations
                .Where(l => l.DestinationId == destinationId)
                .Select(l => new { l.Id, l.Name })
                .ToList();
            return Json(locations);
        }

        [HttpGet("TripPlanner/GetHotels")]
        public JsonResult GetHotels(int locationId, List<int> starRatings)
        {
            var hotelsQuery = _context.Hotels
                .Where(h => h.LocationId == locationId);

            if (starRatings != null && starRatings.Count > 0)
            {
                hotelsQuery = hotelsQuery.Where(h => starRatings.Contains(h.Rating));
            }

            var hotels = hotelsQuery
                .Select(h => new { h.Id, h.Name })
                .ToList();

            return Json(hotels);
        }

        [HttpGet("TripPlanner/GetHotelRooms")]
        public JsonResult GetHotelRooms(int hotelId)
        {
            var hotelRooms = _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId)
                .Select(hr => new
                {
                    hr.Id,
                    hr.RoomType,
                    hr.Inclusions,
                    hr.priceonseason,
                    hr.priceoffseason,
                    hr.capacity,
                    hr.extrachargeperperson
                })
                .ToList();

            return Json(hotelRooms);
        }

        [HttpGet("TripPlanner/GetTransports/{locationId}")]
        public JsonResult GetTransports(int locationId)
        {
            var transports = _context.Transports
                .Where(t => t.LocationId == locationId)
                .Select(t => new { t.Id, t.CarType, t.BasePrice, t.PricePerKm, t.BaseDistance })
                .ToList();
            return Json(transports);
        }

        [HttpGet("TripPlanner/GetSightseeings/{destinationId}")]
        public JsonResult GetSightseeings(int destinationId)
        {
            var sightseeings = _context.Sightseeings
        .Where(s => s.Location.DestinationId == destinationId)  // Join based on DestinationId
        .Select(s => new { s.Id, s.Name })
        .ToList();
            return Json(sightseeings);
        }
    }
}
