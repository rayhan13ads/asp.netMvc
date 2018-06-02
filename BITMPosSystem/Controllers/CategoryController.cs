using System;
using System.Collections.Generic;
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
            return View();
        }

        [HttpPost]
        public ActionResult CreateRoot(Category obj)
        {

            var isAdded = _manager.Add(obj);
            if (isAdded)
            {
                ViewBag.Meg = "Sucessful";
            }
            else
            {
                ViewBag.Meg = "Failed";
            }
            return View("Create", obj);
        }
    }
}