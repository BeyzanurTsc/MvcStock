using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class SalesController : Controller
    {
        MvcDbStockEntities db = new MvcDbStockEntities();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddSales()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSales(TBLSALE sale)
        {
            db.TBLSALES.Add(sale);
            db.SaveChanges();
            return View("Index");
        }

    }
}