using Easyourtour.Models;
using Easyourtour.Models.ViewModel;
using Easyourtour.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocation _LocationRepo;
        private readonly ILocationImage _LocationImagesRepo;
        private readonly IDestination _DestinationRepo;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        public LocationController(ILocation db, IDestination cr, IWebHostEnvironment web, ILocationImage pi)
        {
            _LocationRepo = db;
            _LocationImagesRepo = pi;
            _DestinationRepo = cr;
            _IWebHostEnvironment = web;
        }
        public IActionResult Index()
        {
            List<Location> objDestinationList = _LocationRepo.GetAll(includeProperties:"Destination").ToList();

            return View(objDestinationList);
        }
        public IActionResult Upsert(int? id)
        {
            LocationVm LocationVm = new()
            {
                DestinationList = _DestinationRepo.GetAll().Select(u => new SelectListItem
                {

                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Location = new Location()
            };
            if (id == null || id == 0)
            {
                return View(LocationVm);
            }
            else
            {
                LocationVm.Location = _LocationRepo.Get(u => u.Id == id, includeProperties: "LocationImages");
                return View(LocationVm);
            }
        }
        [HttpPost]
        public IActionResult Upsert(LocationVm obj, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                if (obj.Location.Id == 0)
                {
                    _LocationRepo.Add(obj.Location);
                }
                else
                {
                    _LocationRepo.Update(obj.Location);
                }

                _LocationRepo.Save();
                string wwwRootPath = _IWebHostEnvironment.WebRootPath;
                if (Files != null)
                {
                    foreach (IFormFile File in Files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                        string LocationPath = @"images\Locations\Location-" + obj.Location.Id;
                        string finalpath = Path.Combine(wwwRootPath, LocationPath);
                        if (!Directory.Exists(finalpath))
                        {
                            Directory.CreateDirectory(finalpath);
                        }
                        using (var filestream = new FileStream(Path.Combine(finalpath, fileName), FileMode.Create))
                        {
                            File.CopyTo(filestream);
                        }
                        LocationImage LocationImage = new()
                        {
                            ImageUrl = @"\" + LocationPath + @"/" + fileName,
                            LocationId = obj.Location.Id,

                        };
                        if (obj.Location.LocationImages == null)
                            obj.Location.LocationImages = new List<LocationImage>();
                        obj.Location.LocationImages.Add(LocationImage);

                    }
                    _LocationRepo.Update(obj.Location);
                    _LocationRepo.Save();
                }

                TempData["success"] = "Location created/updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.DestinationList = _DestinationRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }

        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _LocationImagesRepo.Get(u => u.Id == imageId);
            int LocationId = imageToBeDeleted.LocationId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_IWebHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                }
                _LocationImagesRepo.Remove(imageToBeDeleted);
                _LocationImagesRepo.Save();
                TempData["Success"] = "Deleted Succesfully";
            }
            return RedirectToAction(nameof(Upsert), new { id = LocationId });
        }
        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Location> objLocationList = _LocationRepo.GetAll(includeProperties: "Destination").ToList();
            return Json(new { data = objLocationList });
        }
        public IActionResult Delete(int id)
        {
            var LocationToBeDeleted = _LocationRepo.Get(u => u.Id == id);
            if (LocationToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string LocationPath = @"images\Locations\Location-" + id;
            string finalPath = Path.Combine(_IWebHostEnvironment.WebRootPath, LocationPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _LocationRepo.Remove(LocationToBeDeleted);
            _LocationRepo.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion


    }
}
