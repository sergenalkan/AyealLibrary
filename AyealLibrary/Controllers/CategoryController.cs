using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AyealLibrary.Models.Entity;
namespace AyealLibrary.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DbLibraryEntities db = new DbLibraryEntities();
        public ActionResult Index()
        {
            var degerler = db.TblCategories.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(TblCategories c)
        {

            db.TblCategories.Add(c);
            db.SaveChanges();
            return View();

        }
        public ActionResult CategoryDelete(int id)
        {
            var category = db.TblCategories.Find(id);
            db.TblCategories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryGet(int id)
        {
            var category = db.TblCategories.Find(id);
            return View("CategoryGet",category);
        }

        public ActionResult CategoryUpdate(TblCategories c)
        {
            var category = db.TblCategories.Find(c.Id);
            category.Name = c.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}