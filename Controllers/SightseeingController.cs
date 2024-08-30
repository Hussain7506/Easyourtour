using Easyourtour.Models.ViewModel;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Controllers
{
    public class SightseeingController : Controller
    {
        private readonly ILocation _LocationRepo;
        private readonly ISightseeingImage _SightseeingImagesRepo;
        private readonly ISightseeing _SightseeingRepo;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        public SightseeingController(ISightseeing db, ILocation cr, IWebHostEnvironment web, ISightseeingImage pi)
        {
            _SightseeingRepo = db;
            _SightseeingImagesRepo = pi;
            _LocationRepo = cr;
            _IWebHostEnvironment = web;
        }
        public IActionResult Index()
        {
            List<Sightseeing> objLocationList = _SightseeingRepo.GetAll(includeProperties: "Location").ToList();

            return View(objLocationList);
        }
        public IActionResult Upsert(int? id)
        {
            SightseeingVm SightseeingVm = new()
            {
                LocationList = _LocationRepo.GetAll().Select(u => new SelectListItem
                {

                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Sightseeing = new Sightseeing()
            };
            if (id == null || id == 0)
            {
                return View(SightseeingVm);
            }
            else
            {
                SightseeingVm.Sightseeing = _SightseeingRepo.Get(u => u.Id == id, includeProperties: "SightseeingImages");
                return View(SightseeingVm);
            }
        }
        [HttpPost]
        public IActionResult Upsert(SightseeingVm obj, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                if (obj.Sightseeing.Id == 0)
                {
                    _SightseeingRepo.Add(obj.Sightseeing);
                }
                else
                {
                    _SightseeingRepo.Update(obj.Sightseeing);
                }

                _SightseeingRepo.Save();
                string wwwRootPath = _IWebHostEnvironment.WebRootPath;
                if (Files != null)
                {
                    foreach (IFormFile File in Files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                        string SightseeingPath = @"images\Sightseeings\Sightseeing-" + obj.Sightseeing.Id;
                        string finalpath = Path.Combine(wwwRootPath, SightseeingPath);
                        if (!Directory.Exists(finalpath))
                        {
                            Directory.CreateDirectory(finalpath);
                        }
                        using (var filestream = new FileStream(Path.Combine(finalpath, fileName), FileMode.Create))
                        {
                            File.CopyTo(filestream);
                        }
                        SightseeingImage SightseeingImage = new()
                        {
                            ImageUrl = @"\" + SightseeingPath + @"/" + fileName,
                            SightseeingId = obj.Sightseeing.Id,

                        };
                        if (obj.Sightseeing.SightseeingImages == null)
                            obj.Sightseeing.SightseeingImages = new List<SightseeingImage>();
                        obj.Sightseeing.SightseeingImages.Add(SightseeingImage);

                    }
                    _SightseeingRepo.Update(obj.Sightseeing);
                    _SightseeingRepo.Save();
                }

                TempData["success"] = "Sightseeing created/updated successfully";
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
            var imageToBeDeleted = _SightseeingImagesRepo.Get(u => u.Id == imageId);
            int SightseeingId = imageToBeDeleted.SightseeingId;
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
                _SightseeingImagesRepo.Remove(imageToBeDeleted);
                _SightseeingImagesRepo.Save();
                TempData["Success"] = "Deleted Succesfully";
            }
            return RedirectToAction(nameof(Upsert), new { id = SightseeingId });
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

                    var Sightseeing = new Sightseeing
                    {
                        Name = values[0],
                        LocationId = int.Parse(values[1]),
                        EntryFee = int.Parse(values[2])


                    };
                    _SightseeingRepo.Add(Sightseeing);

                    line = await reader.ReadLineAsync();
                }
            }

            _SightseeingRepo.Save();
            return RedirectToAction("Index"); // Redirect to a suitable action
        }
        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Sightseeing> objSightseeingList = _SightseeingRepo.GetAll(includeProperties: "Location").ToList();
            return Json(new { data = objSightseeingList });
        }
        public IActionResult Delete(int id)
        {
            var SightseeingToBeDeleted = _SightseeingRepo.Get(u => u.Id == id);
            if (SightseeingToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string SightseeingPath = @"images\Sightseeings\Sightseeing-" + id;
            string finalPath = Path.Combine(_IWebHostEnvironment.WebRootPath, SightseeingPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _SightseeingRepo.Remove(SightseeingToBeDeleted);
            _SightseeingRepo.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
