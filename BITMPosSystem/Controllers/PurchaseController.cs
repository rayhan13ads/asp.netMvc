using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitmPosSystem.BLL;
using BitmPosSystem.Models;
using BitmPosSystem.Models.Context;

namespace BITMPosSystem.Controllers
{
    public class PurchaseController : Controller
    {
        private PosSystemContext _db = new PosSystemContext();
        // GET: Purchase
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid && purchase.PurchaseDetailses !=null && purchase.PurchaseDetailses.Count>0)
            {
                _db.PurchaseTable.Add(purchase);
                var isPurchaseAdded = _db.SaveChanges() > 0;
                if (isPurchaseAdded)
                {
                    return View(purchase);
                } 
            }
            return View();
        }
    }
}