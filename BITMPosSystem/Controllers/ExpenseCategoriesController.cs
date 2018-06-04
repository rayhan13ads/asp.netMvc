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
    public class ExpenseCategoriesController : Controller
    {
        private PosSystemContext db = new PosSystemContext();

        // GET: ExpenseCategories
        public ActionResult Index()
        {
            var expenseCategories = db.ExpenseCategories.Include(e => e.ExpenseRootCategory);
            return View(expenseCategories.ToList());
        }

        // GET: ExpenseCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseRootCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name");
            return View();
        }

        // POST: ExpenseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ExpanseCode,Description,Image,ExpenseRootCategoryId")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCategories.Add(expenseCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseRootCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expenseCategory.ExpenseRootCategoryId);
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseRootCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expenseCategory.ExpenseRootCategoryId);
            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ExpanseCode,Description,Image,ExpenseRootCategoryId")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseRootCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expenseCategory.ExpenseRootCategoryId);
            return View(expenseCategory);
        }

        // GET: ExpenseCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // POST: ExpenseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseCategory expenseCategory = db.ExpenseCategories.Find(id);
            db.ExpenseCategories.Remove(expenseCategory);
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
