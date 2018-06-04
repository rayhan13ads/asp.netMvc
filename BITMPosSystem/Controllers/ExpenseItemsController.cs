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
    public class ExpenseItemsController : Controller
    {
        private PosSystemContext db = new PosSystemContext();

        // GET: ExpenseItems
        public ActionResult Index()
        {
            var expenseItems = db.ExpenseItems.Include(e => e.ExpenseCategory);
            return View(expenseItems.ToList());
        }

        // GET: ExpenseItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return View(expenseItem);
        }

        // GET: ExpenseItems/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name");
            return View();
        }

        // POST: ExpenseItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExpenseItemName,ExpenseItemCode,Description,ExpenseCategoryId")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseItems.Add(expenseItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expenseItem.ExpenseCategoryId);
            return View(expenseItem);
        }

        // GET: ExpenseItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expenseItem.ExpenseCategoryId);
            return View(expenseItem);
        }

        // POST: ExpenseItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExpenseItemName,ExpenseItemCode,Description,ExpenseCategoryId")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseCategoryId = new SelectList(db.ExpenseCategories, "Id", "Name", expenseItem.ExpenseCategoryId);
            return View(expenseItem);
        }

        // GET: ExpenseItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return View(expenseItem);
        }

        // POST: ExpenseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseItem expenseItem = db.ExpenseItems.Find(id);
            db.ExpenseItems.Remove(expenseItem);
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
