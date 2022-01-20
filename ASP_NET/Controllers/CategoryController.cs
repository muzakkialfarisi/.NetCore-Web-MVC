using ASP.DataAccess;
using ASP.DataAccess.Repository.IRepository;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll(); //buat ambil data dari database
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
                _db.Add(obj); //untuk menambahkan objek baru ke db
                _db.Save();
                TempData["success"] = "sukses dibuat";
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

            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.GetFirstOrDefault(x => x.Id==id);

            if(categoryFromDbFirst == null)
            {
                return BadRequest();
            }
            return View(categoryFromDbFirst);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Pesan bebas"); //sukasuka validation All
                //gausah panggil fungsi diatas, kalau mau semua list keluar
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj); //update
                _db.Save();
                TempData["success"] = "sukses diupdate";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.GetFirstOrDefault(x => x.Id == id);

            if (categoryFromDb == null)
            {
                return BadRequest();
            }
            return View(categoryFromDb);
        }

        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.GetFirstOrDefault(x=>x.Id==id);
            if (obj is null)
            {
                return NotFound();
            }
            _db.Remove(obj); //update
            _db.Save();
            TempData["success"] = "sukses dihapus";
            return RedirectToAction("Index");
        }
    }
}
