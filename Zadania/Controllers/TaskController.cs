using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadania.Data;
using Zadania.Helpers.SRTProcessor;
using Zadania.Models;

namespace Zadania.Controllers
{
    public class TaskController : Controller
    {

        private readonly ILogger<TaskController> _logger;

        private readonly DatabaseContext _context;

        public TaskController(
            ILogger<TaskController> logger,
            DatabaseContext context
            )
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskEntry taskEntry)
        {
            if (ModelState.IsValid)
            {
                
                _context.Tasks.Add(taskEntry);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(taskEntry);
        }

        [HttpPost]
        public IActionResult Stop(int id)
        {
            var taskEntry = _context.Tasks.Find(id);
            if (taskEntry != null)
            {
                
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }



    }
}

