using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTodo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new Models.MyDbContext())
            {
                db.Tasks.Add(new Models.Task {
                    Name = "The Name",
                    Archived = false,
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                });
                db.SaveChanges();
                ViewBag.Count = db.Tasks.Count();
            }
            return View();
        }
    }
}