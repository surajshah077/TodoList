using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{

    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            List<Todo> todos = _context.Todos.ToList();
            ViewBag.Todo = todos;
            if (id == null)
                return View();
            else
            {
                Todo? toDo = _context.Todos.FirstOrDefault(x => x.Id == id);
                return View(toDo);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Todo todo)
        {
            var result = todo.Id == 0 ? _context.Todos.Add(todo) : _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Todo? todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
