using Easyourtour.Models;
using Easyourtour.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Easyourtour.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestination _DestinationRepo;
        public DestinationController(IDestination db)
        {
            _DestinationRepo = db;
        }
        public IActionResult Index()
        {
            List<Destination> objCategoryList = _DestinationRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Destination obj)
        {


            if (ModelState.IsValid)
            {
                _DestinationRepo.Add(obj);
                _DestinationRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Destination? DestinationFromDb = _DestinationRepo.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (DestinationFromDb == null)
            {
                return NotFound();
            }
            return View(DestinationFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Destination obj)
        {
            if (ModelState.IsValid)
            {
                _DestinationRepo.Update(obj);
                _DestinationRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Destination? DestinationFromDb = _DestinationRepo.Get(u => u.Id == id);

            if (DestinationFromDb == null)
            {
                return NotFound();
            }
            return View(DestinationFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Destination? obj = _DestinationRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _DestinationRepo.Remove(obj);
            _DestinationRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
