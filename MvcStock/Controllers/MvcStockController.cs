using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    public class MvcStockController : Controller
    {
        // GET: MvcStock
        public ActionResult Index()
        {
            return View();
        }
    }
}