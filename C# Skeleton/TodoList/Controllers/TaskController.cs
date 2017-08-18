using System;
using System.Linq;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
	public class TaskController : Controller
	{
	    [HttpGet]
        [Route("")]
	    public ActionResult Index()
	    {
            //TODO: Implement me...
            using (var database = new TodoListDbContext())
            {
                var tasks = database.Tasks.ToList();
                return View(tasks);
            }
                
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
            return View();

        }

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
            using (var database = new TodoListDbContext())
            {
                database.Tasks.Add(task);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
                
        }

		[HttpGet]
		[Route("delete/{id}")]
        public ActionResult Delete(int id)
		{
            using (var database = new TodoListDbContext())
            {
                var task = database.Tasks.Find(id);
                return View(task);
            }
                
        }

		[HttpPost]
		[Route("delete/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(int id)
		{
            using (var database = new TodoListDbContext())
            {
                var task = database.Tasks.Find(id);
                database.Tasks.Remove(task);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
                
        }
	}
}