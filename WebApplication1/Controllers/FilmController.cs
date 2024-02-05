using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FilmController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FilmController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            List<Film> objFilmList = _db.Films.ToList();
            return View(objFilmList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Film obj) {
            _db.Films.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0) { return NotFound(); }
            Film? filmFromDb = _db.Films.Find(id);

            if (filmFromDb == null) 
            { 
                return NotFound(); 
            }
            return View(filmFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Film obj)
        {
             
            _db.Films.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            Film? filmFromDb = _db.Films.Find(id);

            if (filmFromDb == null)
            {
                return NotFound();
            }
            return View(filmFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Film? obj = _db.Films.Find(id);
            if (obj==null)
            { 
                return NotFound();
            }
   

            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
