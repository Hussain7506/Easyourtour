using Easyourtour.Models.ViewModel;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILocation _LocationRepo;
        private readonly IHotelImage _HotelImagesRepo;
        private readonly IHotel _HotelRepo;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        public HotelController(IHotel db, ILocation cr, IWebHostEnvironment web, IHotelImage pi)
        {
            _HotelRepo = db;
            _HotelImagesRepo = pi;
            _LocationRepo = cr;
            _IWebHostEnvironment = web;
        }
        public IActionResult Index()
        {
            List<Hotel> objLocationList = _HotelRepo.GetAll(includeProperties:"Location").ToList();

            return View(objLocationList);
        }
        public IActionResult Upsert(int? id)
        {
            HotelVm HotelVm = new()
            {
                LocationList = _LocationRepo.GetAll().Select(u => new SelectListItem
                {

                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Hotel = new Hotel()
            };
            if (id == null || id == 0)
            {
                return View(HotelVm);
            }
            else
            {
                HotelVm.Hotel = _HotelRepo.Get(u => u.Id == id, includeProperties: "HotelImages");
                return View(HotelVm);
            }
        }
        [HttpPost]
        public IActionResult Upsert(HotelVm obj, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                if (obj.Hotel.Id == 0)
                {
                    _HotelRepo.Add(obj.Hotel);
                }
                else
                {
                    _HotelRepo.Update(obj.Hotel);
                }

                _HotelRepo.Save();
                string wwwRootPath = _IWebHostEnvironment.WebRootPath;
                if (Files != null)
                {
                    foreach (IFormFile File in Files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                        string HotelPath = @"images\Hotels\Hotel-" + obj.Hotel.Id;
                        string finalpath = Path.Combine(wwwRootPath, HotelPath);
                        if (!Directory.Exists(finalpath))
                        {
                            Directory.CreateDirectory(finalpath);
                        }
                        using (var filestream = new FileStream(Path.Combine(finalpath, fileName), FileMode.Create))
                        {
                            File.CopyTo(filestream);
                        }
                        HotelImage HotelImage = new()
                        {
                            ImageUrl = @"\" + HotelPath + @"/" + fileName,
                            HotelId = obj.Hotel.Id,

                        };
                        if (obj.Hotel.HotelImages == null)
                            obj.Hotel.HotelImages = new List<HotelImage>();
                        obj.Hotel.HotelImages.Add(HotelImage);

                    }
                    _HotelRepo.Update(obj.Hotel);
                    _HotelRepo.Save();
                }

                TempData["success"] = "Hotel created/updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.LocationList = _LocationRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }

        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _HotelImagesRepo.Get(u => u.Id == imageId);
            int HotelId = imageToBeDeleted.HotelId;
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
                _HotelImagesRepo.Remove(imageToBeDeleted);
                _HotelImagesRepo.Save();
                TempData["Success"] = "Deleted Succesfully";
            }
            return RedirectToAction(nameof(Upsert), new { id = HotelId });
        }
        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0 || Path.GetExtension(file.FileName) != ".csv")
            {
                ModelState.AddModelError("file", "Please upload a valid CSV file.");
                return View();
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                await reader.ReadLineAsync();
                var line = await reader.ReadLineAsync();
                while (line != null)
                {
                    var values = line.Split(',');

                    var Hotel = new Hotel
                    {
                        Name = values[0],
                        LocationId = int.Parse(values[1]),
                        Amenities=values[2]


                    };
                    _HotelRepo.Add(Hotel);

                    line = await reader.ReadLineAsync();
                }
            }

            _HotelRepo.Save();
            return RedirectToAction("Index"); // Redirect to a suitable action
        }
        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Hotel> objHotelList = _HotelRepo.GetAll(includeProperties: "Location").ToList();
            return Json(new { data = objHotelList });
        }
        public IActionResult Delete(int id)
        {
            var HotelToBeDeleted = _HotelRepo.Get(u => u.Id == id);
            if (HotelToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string HotelPath = @"images\Hotels\Hotel-" + id;
            string finalPath = Path.Combine(_IWebHostEnvironment.WebRootPath, HotelPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _HotelRepo.Remove(HotelToBeDeleted);
            _HotelRepo.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
