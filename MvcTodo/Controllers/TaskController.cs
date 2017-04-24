using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTodo.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        [HttpGet]
        public ActionResult Index()
        {
            var db = new Models.MyDbContext();
            return View(db.Tasks.ToList());
        }

        [HttpPost]
        public ActionResult Create(string text)
        {
            return Content(text);
        }
    }
}