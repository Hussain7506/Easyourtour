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

        // GET: /TripPlanner/CreateTemplate
        public IActionResult CreateTemplate()
        {
            var model = new TripPlanVM
            {
                NumberOfDays = 0
            };

            PopulateDropdowns(model);
            return View(model);
        }

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
                    travelandSightSeeingSpots = new List<TravelandSightSeeingSpot>(),
                    DestinationandHotel = new List<DestinationandHotels>(),
                    FinalCost=model.FinalCost
                };

                foreach (var destinationHotelVM in model.DestinationandHotels)
                {
                    var destinationHotel = new DestinationandHotels
                    {
                        DayItineraries = new List<DayItinerary>(),
                        HotelCost = destinationHotelVM.Hotelcost,
                        OptionNumber = destinationHotelVM.OptionNumber
                    };

                    foreach (var dayVM in destinationHotelVM.Days)
                    {
                        var dayItinerary = new DayItinerary
                        {
                            DayNumber = dayVM.DayNumber,
                            DestinationId = dayVM.DestinationId,
                            LocationId = dayVM.LocationId
                        };

                        foreach (var roomVM in dayVM.Rooms)
                        {
                            var room = new DayItineraryRoom
                            {
                                HotelRoomId = roomVM.HotelRoomId,
                                NumberOfRooms = roomVM.NumberOfRooms,
                                ExtraPersons = roomVM.ExtraPersons,
                                TotalRoomCost = roomVM.TotalRoomCost
                            };
                            dayItinerary.DayItineraryRooms.Add(room);
                        }

                        destinationHotel.DayItineraries.Add(dayItinerary);
                    }

                    template.DestinationandHotel.Add(destinationHotel);
                }
                foreach (var travelSightseeingVM in model.TravelandSightSeeingSpots)
                {
                    var travelSightseeing = new TravelandSightSeeingSpot
                    {
                        TemplateId = template.Id, // Assuming the template ID will be assigned after saving
                        TransportId = travelSightseeingVM.TransportId,
                        DayItinerarySightseeings = new List<DayItinerarySightseeing>(),
                        Kilometers = travelSightseeingVM.Kilometers,
                        TotalCost = travelSightseeingVM.TotalCost
                    };

                    // Loop through SightseeingIds to create DayItinerarySightseeings
                    foreach (var sightseeingId in travelSightseeingVM.SightseeingIds)
                    {
                        var sightseeing = new DayItinerarySightseeing
                        {
                            SightseeingId = sightseeingId,
                        };
                        travelSightseeing.DayItinerarySightseeings.Add(sightseeing);
                    }

                    template.travelandSightSeeingSpots.Add(travelSightseeing);
                }

                _context.Templates.Add(template);
                await _context.SaveChangesAsync();

                return RedirectToAction("ViewTemplate", new { templateId = template.Id });
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

        [HttpGet("TripPlanner/GetSightseeings/{locationId}")]
        public JsonResult GetSightseeings(int locationId)
        {
            var sightseeings = _context.Sightseeings
                .Where(s => s.LocationId == locationId)
                .Select(s => new { s.Id, s.Name })
                .ToList();
            return Json(sightseeings);
        }
    }
}
