using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult ProductList(string pt)
        {
            var prdct = from p in db.TBLPRODUCTs select p;
            if (!string.IsNullOrEmpty(pt))
            {
                prdct = prdct.Where(p => p.PRODUCTNAME.Contains(pt));
            }
            return View(prdct.ToList());
            //var prdct = db.TBLPRODUCTs.ToList();
            //return View(prdct);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> categories = (from ctgr in db.TBL_CATEGORY.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = ctgr.CATEGORYNAME,
                                                 Value = ctgr.CATEGORYID.ToString()
                                             }).ToList();
            ViewBag.ctgrs = categories;//categories den gelen değeri view e gönderdik.
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(TBLPRODUCT product)
        {
            var ctg = db.TBL_CATEGORY.Where(p => p.CATEGORYID == product.TBL_CATEGORY.CATEGORYID).FirstOrDefault();
            product.TBL_CATEGORY = ctg;
            db.TBLPRODUCTs.Add(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult DeleteProduct(int id)
        {
            var deleted = db.TBLPRODUCTs.Find(id);
            db.TBLPRODUCTs.Remove(deleted);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult GetProduct(int id)
        { 
            var pro = db.TBLPRODUCTs.Find(id);
            List<SelectListItem> categories = (from ctg in db.TBL_CATEGORY.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = ctg.CATEGORYNAME,
                                                   Value = ctg.CATEGORYID.ToString()
                                               }).ToList();
            ViewBag.ctgrs = categories;
          
            return View("GetProduct", pro);

        }
        public ActionResult UpdateProduct(TBLPRODUCT product)
        {
            var updatedPro = db.TBLPRODUCTs.Find(product.PRODUCTID);
            updatedPro.PRODUCTNAME = product.PRODUCTNAME;
            updatedPro.PRODUCTBRAND = product.PRODUCTBRAND;
            updatedPro.PRODUCTPRICE = product.PRODUCTPRICE;
            updatedPro.PRODUCTSTOCK = product.PRODUCTSTOCK;
            var ctg = db.TBL_CATEGORY.Where(c => c.CATEGORYID == product.TBL_CATEGORY.CATEGORYID).FirstOrDefault();
            updatedPro.PRODUCTCATEGORY = ctg.CATEGORYID;
            db.SaveChanges();
            return RedirectToAction("ProductList");

        }
    }
}