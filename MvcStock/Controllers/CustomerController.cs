using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStock.Models.Entity;

namespace MvcStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult CustomerList()
        {
            var cstmr = db.TBL_CUSTOMER.ToList();
            return View(cstmr);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(TBL_CUSTOMER customer)
        {
            if(!ModelState.IsValid)
            {
                return View("AddCustomer");
            }

            db.TBL_CUSTOMER.Add(customer);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCustomer(int id)
        {
            var deletedCstmr = db.TBL_CUSTOMER.Find(id);
            db.TBL_CUSTOMER.Remove(deletedCstmr);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public  ActionResult GetCustomer(int id)
        {
            var cus = db.TBL_CUSTOMER.Find(id);
            return View("GetCustomer",cus);
        }
        public ActionResult UpdateCustomer(TBL_CUSTOMER cstmr)
        {
            var updatedCus = db.TBL_CUSTOMER.Find(cstmr.CUSTOMERID);
            updatedCus.CUSTOMERNAME = cstmr.CUSTOMERNAME;
            updatedCus.CUSTOMERSURNAME = cstmr.CUSTOMERSURNAME;
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }
    }
}