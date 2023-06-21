using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult CategoryList(int page=1)
        {
            //var categories = db.TBL_CATEGORY.ToList();
            var categories = db.TBL_CATEGORY.ToList().ToPagedList(page, 4);//1.sayfadan başlayacak her sayfada 4 veri listelenecek
            return View(categories);
        }

        //Sayfada herhangi bir işlem gerçekleşmezse.
        [HttpGet] 
        public ActionResult AddCategory()
        {
            return View();
        }

        //Sayfada butona basılırsa kaydetme,gönderme işlemi gerçekleşirse.
        [HttpPost] 
        public ActionResult AddCategory(TBL_CATEGORY category)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory");
            }
            db.TBL_CATEGORY.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var deletedCtg = db.TBL_CATEGORY.Find(id);
            db.TBL_CATEGORY.Remove(deletedCtg);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult GetCategory(int id)
        {
            var ctgr = db.TBL_CATEGORY.Find(id);
            return View("GetCategory", ctgr);
        }
        public ActionResult UpdateCategory(TBL_CATEGORY ctgr)
        {
            var ctg = db.TBL_CATEGORY.Find(ctgr.CATEGORYID);
            ctg.CATEGORYNAME = ctgr.CATEGORYNAME;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}