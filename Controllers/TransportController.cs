using Easyourtour.Models.ViewModel;
using Easyourtour.Models;
using Easyourtour.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Easyourtour.Controllers
{
    public class TransportController : Controller
    {
        private readonly ILocation _LocationRepo;
        private readonly ITransport _TransportRepo;
        public TransportController(ITransport db, ILocation cr )
        {
            _TransportRepo = db;
            _LocationRepo = cr;
        }
        public IActionResult Index()
        {
            List<Transport> objLocationList = _TransportRepo.GetAll(includeProperties: "Location").ToList();

            return View(objLocationList);
        }
        public IActionResult Upsert(int? id)
        {
            TransportVm TransportVm = new()
            {
                LocationList = _LocationRepo.GetAll().Select(u => new SelectListItem
                {

                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Transport = new Transport()
            };
            if (id == null || id == 0)
            {
                return View(TransportVm);
            }
            else
            {
                TransportVm.Transport = _TransportRepo.Get(u => u.Id == id);
                return View(TransportVm);
            }
        }
        [HttpPost]
        public IActionResult Upsert(TransportVm obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Transport.Id == 0)
                {
                    _TransportRepo.Add(obj.Transport);
                }
                else
                {
                    _TransportRepo.Update(obj.Transport);
                }

                _TransportRepo.Save();
                TempData["success"] = "Transport created/updated successfully";
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

                    var Transport = new Transport
                    {
                        CarType = values[0],
                        CarCap = int.Parse(values[1]),
                        BaseDistance = int.Parse(values[2]),
                        BasePrice = int.Parse(values[3]),
                        PricePerKm = int.Parse(values[4]),
                        LocationId = int.Parse(values[5])
                    };
                    _TransportRepo.Add(Transport);

                    line = await reader.ReadLineAsync();
                }
            }

            _TransportRepo.Save();
            return RedirectToAction("Index"); // Redirect to a suitable action
        }
        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Transport> objTransportList = _TransportRepo.GetAll(includeProperties: "Location").ToList();
            return Json(new { data = objTransportList });
        }
        public IActionResult Delete(int id)
        {
            var TransportToBeDeleted = _TransportRepo.Get(u => u.Id == id);
            if (TransportToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _TransportRepo.Remove(TransportToBeDeleted);
            _TransportRepo.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
