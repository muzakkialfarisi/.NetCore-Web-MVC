using ASP.DataAccess;
using ASP.DataAccess.Repository.IRepository;
using ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll(); //buat ambil data dari database
            return View(objCoverTypeList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj); //untuk menambahkan objek baru ke db
                _unitOfWork.Save();
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

            var covertypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id==id);

            if(covertypeFromDbFirst == null)
            {
                return BadRequest();
            }
            return View(covertypeFromDbFirst);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            //    ModelState.AddModelError("CustomError", "Pesan bebas"); //sukasuka validation All
            //    //gausah panggil fungsi diatas, kalau mau semua list keluar
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj); //update
                _unitOfWork.Save();
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
            var covertypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (covertypeFromDb == null)
            {
                return BadRequest();
            }
            return View(covertypeFromDb);
        }

        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);
            if (obj is null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj); //update
            _unitOfWork.Save();
            TempData["success"] = "sukses dihapus";
            return RedirectToAction("Index");
        }
    }
}
