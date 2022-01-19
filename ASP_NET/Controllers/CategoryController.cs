using ASP_NET.Data;
using ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories; //buat ambil data dari database
            return View(objCategoryList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Pesan bebas"); //sukasuka validation All
                //gausah panggil fungsi diatas, kalau mau semua kist keluar
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj); //untuk menambahkan objek baru ke db
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if(categoryFromDb == null)
            {
                return BadRequest();
            }
            return View(categoryFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Pesan bebas"); //sukasuka validation All
                //gausah panggil fungsi diatas, kalau mau semua kist keluar
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj); //update
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
