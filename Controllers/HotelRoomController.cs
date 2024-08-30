using Easyourtour.Models.ViewModel;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly IHotel _HotelRepo;
        private readonly IHotelRoomImage _HotelRoomImagesRepo;
        private readonly IHotelRoom _HotelRoomRepo;
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        public HotelRoomController(IHotelRoom db, IHotel cr, IWebHostEnvironment web, IHotelRoomImage pi)
        {
            _HotelRoomRepo = db;
            _HotelRoomImagesRepo = pi;
            _HotelRepo = cr;
            _IWebHostEnvironment = web;
        }
        public IActionResult Index()
        {
            List<HotelRoom> objHotelList = _HotelRoomRepo.GetAll(includeProperties: "Hotel").ToList();

            return View(objHotelList);
        }
        public IActionResult Upsert(int? id)
        {
            HotelRoomVm HotelRoomVm = new()
            {
                HotelList = _HotelRepo.GetAll().Select(u => new SelectListItem
                {

                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                HotelRoom = new HotelRoom()
            };
            if (id == null || id == 0)
            {
                return View(HotelRoomVm);
            }
            else
            {
                HotelRoomVm.HotelRoom = _HotelRoomRepo.Get(u => u.Id == id, includeProperties: "HotelRoomImages");
                return View(HotelRoomVm);
            }
        }
        [HttpPost]
        public IActionResult Upsert(HotelRoomVm obj, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                if (obj.HotelRoom.Id == 0)
                {
                    _HotelRoomRepo.Add(obj.HotelRoom);
                }
                else
                {
                    _HotelRoomRepo.Update(obj.HotelRoom);
                }

                _HotelRoomRepo.Save();
                string wwwRootPath = _IWebHostEnvironment.WebRootPath;
                if (Files != null)
                {
                    foreach (IFormFile File in Files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                        string HotelRoomPath = @"images\HotelRooms\HotelRoom-" + obj.HotelRoom.Id;
                        string finalpath = Path.Combine(wwwRootPath, HotelRoomPath);
                        if (!Directory.Exists(finalpath))
                        {
                            Directory.CreateDirectory(finalpath);
                        }
                        using (var filestream = new FileStream(Path.Combine(finalpath, fileName), FileMode.Create))
                        {
                            File.CopyTo(filestream);
                        }
                        HotelRoomImage HotelRoomImage = new()
                        {
                            ImageUrl = @"\" + HotelRoomPath + @"/" + fileName,
                            HotelRoomId = obj.HotelRoom.Id,

                        };
                        if (obj.HotelRoom.HotelRoomImages == null)
                            obj.HotelRoom.HotelRoomImages = new List<HotelRoomImage>();
                        obj.HotelRoom.HotelRoomImages.Add(HotelRoomImage);

                    }
                    _HotelRoomRepo.Update(obj.HotelRoom);
                    _HotelRoomRepo.Save();
                }

                TempData["success"] = "HotelRoom created/updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.HotelList = _HotelRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(obj);
            }

        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _HotelRoomImagesRepo.Get(u => u.Id == imageId);
            int HotelRoomId = imageToBeDeleted.HotelRoomId;
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
                _HotelRoomImagesRepo.Remove(imageToBeDeleted);
                _HotelRoomImagesRepo.Save();
                TempData["Success"] = "Deleted Succesfully";
            }
            return RedirectToAction(nameof(Upsert), new { id = HotelRoomId });
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

                    var HotelRoom = new HotelRoom
                    {
                        RoomType = values[0],
                        priceonseason = double.Parse(values[1]),
                        priceoffseason = double.Parse(values[2]),
                        capacity=int.Parse(values[3]),
                        extrachargeperperson = double.Parse(values[4]),
                        HotelId=int.Parse(values[5]),
                        Inclusions=values[6]


                    };
                    _HotelRoomRepo.Add(HotelRoom);

                    line = await reader.ReadLineAsync();
                }
            }

            _HotelRoomRepo.Save();
            return RedirectToAction("Index"); // Redirect to a suitable action
        }
        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<HotelRoom> objHotelRoomList = _HotelRoomRepo.GetAll(includeProperties: "Hotel").ToList();
            return Json(new { data = objHotelRoomList });
        }
        public IActionResult Delete(int id)
        {
            var HotelRoomToBeDeleted = _HotelRoomRepo.Get(u => u.Id == id);
            if (HotelRoomToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string HotelRoomPath = @"images\HotelRooms\HotelRoom-" + id;
            string finalPath = Path.Combine(_IWebHostEnvironment.WebRootPath, HotelRoomPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _HotelRoomRepo.Remove(HotelRoomToBeDeleted);
            _HotelRoomRepo.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
