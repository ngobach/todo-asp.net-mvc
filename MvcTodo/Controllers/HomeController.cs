using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTodo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content(String.Format("Connection string is: <br>{0}", new Models.MyDbContext().Database.Connection.ConnectionString));
        }

        public ActionResult Add()
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