using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadania.Data;
using Zadania.Helpers.SRTProcessor;
using Zadania.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace Zadania.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TaskApiController : ControllerBase
    {

        private readonly ILogger<TaskApiController> _logger;

        private readonly DatabaseContext _context;

        public TaskApiController(
            ILogger<TaskApiController> logger,
            DatabaseContext context
            )
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        [Route("GetTask")]
        public async Task<IEnumerable<TaskEntry>> GetTask()
        {
             var tasks = await _context.Tasks.ToListAsync();
                return tasks;
            

        }

        [HttpPost]
        [Route("AddTask")]
        public async Task<TaskEntryVM> AddTask(TaskEntryVM taskEntryVM)
        {
            if (ModelState.IsValid)
            {
                TaskEntry taskEntry = new TaskEntry();
                taskEntry.Name = taskEntryVM.Name;
                taskEntry.Duration = taskEntryVM.Duration;
                taskEntry.StartTime = DateTime.Now;

                _context.Tasks.Add(taskEntry);
                await _context.SaveChangesAsync();
                return taskEntryVM;
            }

            return taskEntryVM;
        }

        //[HttpPost]
        //public IActionResult Stop(int id)
        //{
        //    var taskEntry = _context.Tasks.Find(id);
        //    if (taskEntry != null)
        //    {
              
        //        _context.SaveChanges();
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPatch]
        //[Route("UpdateTask/{id}")]
        //public async Task<TaskEntry> UpdateTasks(TaskEntry objTask)
        //{
        //    _context.Tasks.Entry(objTask).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return objTask;
        //}

        //[HttpDelete]
        //[Route("DeleteTask/{id}")]
        //public bool DeleteTasks(int id)
        //{
        //    bool a = false;
        //    var task = _context.Tasks.FirstOrDefault(x=>x.Id == id);
        //    if (task != null) 
        //    {
        //        a = true;
        //        _context.Tasks.Entry(task).State = EntityState.Deleted;
        //        _context.SaveChanges();
        //    }
        //    return a;
        //}
    }
}

