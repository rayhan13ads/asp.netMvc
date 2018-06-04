using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitmPosSystem.Models;
using BitmPosSystem.BLL;
namespace BITMPosSystem.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _manager = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
           
            return View(_manager.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
             
            var rootCategory = _manager.GetAllRoot();
            var model = new Category();
            var dropDown = new List<SelectListItem>();
            dropDown.AddRange(rootCategory.Select(c =>
                new SelectListItem() { Value = c.RootCategoryId.ToString(), Text = c.Name }));
            model.SelectListRootCategoryItems = dropDown;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Category obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase file = Request.Files["imageBrowes"];
                    var isAdded = _manager.Add(obj, file);
                    if (isAdded)
                    {
                        ViewBag.Meg = "Sucessful";
                       //return RedirectToAction("Index");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Meg = "Failed";
                    }
                    
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
           
            return View(obj);
        }

       
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category model = _manager.GetByid(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Category objCategory)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imageBrowes"];
                var isAdded = _manager.Update(objCategory, file);
                if (isAdded)
                {
                    ViewBag.Meg = "Update Sucessful";
                }
                else
                {
                    ViewBag.Meg = "Failed";
                }

            }
            return RedirectToAction("Index");

        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category model = _manager.GetByid(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Create");
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             var iSDelete = _manager.Delete(id) ;

            if (iSDelete)
            {
                ViewBag.Meg = "Delete Sucessful";
                //return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Meg = "Failed";
            }

            return RedirectToAction("Index"); ;
        }
    }
}