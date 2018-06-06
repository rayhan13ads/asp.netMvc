using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitmPosSystem.Models;
using BitmPosSystem.BLL;
using BitmPosSystem.Models.Context;

namespace BITMPosSystem.Controllers
{
    public class ItemsController : Controller
    {
        ItemManager _manager = new ItemManager();
        CategoryManager  _categoryManager = new CategoryManager();
        // GET: Items
        public ActionResult Index()
        {
            var items = _manager.GetAll();
            return View(items);
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = _manager.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemName,ItemCode,Description,Image,CategoryId,CostPrice,SalePrice")] Item item)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imageBrowes"];
                _manager.Add(item, file);
               
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_categoryManager.GetAll(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _manager.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryManager.GetAll(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemName,ItemCode,Description,Image,CategoryId,CostPrice,SalePrice")] Item item)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imageBrowes"];
                _manager.Update(item ,file);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_categoryManager.GetAll(), "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = _manager.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _manager.Dispose(disposing);
            }
            base.Dispose(disposing);
        }
    }
}
