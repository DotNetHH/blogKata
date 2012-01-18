using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogKata.Controllers
{
    using blogKata.Models;

    public class HomeController : Controller
    {
        public static Blog currentBlog = new Blog();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Title = "Welcome to my blog";
            
            return View();
        }

        public ViewResult Create()
        {
            return this.View(new BlogEntry(string.Empty));
        }

        [HttpPost]
        public ActionResult Create(BlogEntry blogEntry)
        {
            currentBlog.Add(blogEntry);

            return this.View(blogEntry);
        }
    }
}
