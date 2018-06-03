using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
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
            return View();
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
    }
}