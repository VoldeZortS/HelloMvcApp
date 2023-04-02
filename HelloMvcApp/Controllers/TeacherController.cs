using HelloMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HelloMvcApp.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            List<Ogretmen> lst;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.Ogretmenler.ToList();
            }
            return View(lst);

        }
        [HttpGet]
        public ViewResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddTeacher(Ogretmen ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogretmenler.Add(ogr);
                var sonuc = ctx.SaveChanges();
                if (sonuc > 0)
                {
                    TempData["sonuc"] = true;
                }
                else
                {
                    TempData["sonuc"] = null;
                }
            }
            return View();
        }
        public IActionResult DeleteTeacher(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogretmenler.Find(id);
                ctx.Ogretmenler.Remove(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateTeacher(int id)
        {
            Ogretmen ogr;
            using (var ctx = new OkulDbContext())
            {
                ogr = ctx.Ogretmenler.Find(id);
            }
            return View(ogr);
        }
        [HttpPost]
        public IActionResult UpdateTeacher(Ogretmen ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
