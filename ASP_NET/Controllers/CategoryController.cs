﻿using ASP.DataAccess;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
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
            var categoryFromDbFirst = _db.Categories.FirstOrDefault(x => x.Name == "Id");

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
                _db.Categories.Update(obj); //update
                _db.SaveChanges();
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
            var categoryFromDb = _db.Categories.Find(id);

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
            var obj = _db.Categories.Find(id);
            if (obj is null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj); //update
            _db.SaveChanges();
            TempData["success"] = "sukses dihapus";
            return RedirectToAction("Index");
        }
    }
}
