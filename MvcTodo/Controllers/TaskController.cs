using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTodo.Controllers
{
    public class TaskController : Controller
    {
        private Models.MyDbContext db;
        public TaskController()
        {
            db = new Models.MyDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Tasks.OrderByDescending(task => task.Created).ToList());
        }

        [HttpPost]
        public ActionResult Create(string text)
        {
            if (text == null || text == "")
            {
                Session["alert"] = "Invalid task name!";
                return RedirectToAction("Index");
            }

            var db = new Models.MyDbContext();
            db.Tasks.Add(new Models.Task
            {
                Name = text,
                Archived = false,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(int id, string text, bool? archived)
        {
            var task = db.Tasks.First(t => t.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }
            if (text != null)
            {
                task.Name = text;
            }
            if (archived.HasValue)
            {
                task.Archived = archived.Value;
            }
            db.SaveChanges();
            return Json(new { status = "OK" });
        }

        [HttpPost]
        public ActionResult Truncate()
        {
            db.Tasks.RemoveRange(db.Tasks);
            db.SaveChanges();
            Session["alert"] = "Database truncated!";
            return RedirectToAction("Index");
        }
    }

}