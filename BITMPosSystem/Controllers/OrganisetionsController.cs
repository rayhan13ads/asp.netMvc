using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitmPosSystem.Models;
using BitmPosSystem.Models.Context;

namespace BITMPosSystem.Controllers
{
    public class OrganisetionsController : Controller
    {
        private PosSystemContext db = new PosSystemContext();

        // GET: Organisetions
        public ActionResult Index()
        {
            return View(db.Organisetions.ToList());
        }

        // GET: Organisetions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organisetion = db.Organisetions.Find(id);
            if (organisetion == null)
            {
                return HttpNotFound();
            }
            return View(organisetion);
        }

        // GET: Organisetions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organisetions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganisetionName,OrganisetionCode,ContactNumber,Address,Image")] Organization organisetion)
        {
            if (ModelState.IsValid)
            {
                db.Organisetions.Add(organisetion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organisetion);
        }

        // GET: Organisetions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organisetion = db.Organisetions.Find(id);
            if (organisetion == null)
            {
                return HttpNotFound();
            }
            return View(organisetion);
        }

        // POST: Organisetions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganisetionName,OrganisetionCode,ContactNumber,Address,Image")] Organization organisetion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisetion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organisetion);
        }

        // GET: Organisetions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organisetion = db.Organisetions.Find(id);
            if (organisetion == null)
            {
                return HttpNotFound();
            }
            return View(organisetion);
        }

        // POST: Organisetions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organisetion = db.Organisetions.Find(id);
            db.Organisetions.Remove(organisetion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
