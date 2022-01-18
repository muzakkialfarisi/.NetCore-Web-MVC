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

        public IActionResult Create()
        {
            return View();
        }
    }
}
