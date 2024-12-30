using Assesment.Models;
using Assesment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entites;

namespace Assesment.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext dbcon;

        public TasksController(AppDbContext dbcon)
        {
            this.dbcon = dbcon;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditTask(int id)
        {
            var search = await dbcon.Tasks.FirstOrDefaultAsync(x => x.TasksID == id);
            var projects = await dbcon.Projects.ToListAsync();
            var members = await dbcon.TeamMembers.ToListAsync();

            TaskViewModel vm = new TaskViewModel()
            {
                teamMembers = members,
                projects = projects,
                Title = search.Title,
                Description = search.Description,
                Priority = search.Priority,
                Status = search.Status,
                DeadLine = search.DeadLine,
                ProjectID = search.ProjectID,
                TeamMemberID = search.TeamMemberID,
            };
            return View(vm);
        }
        [HttpPost]
            public async Task<IActionResult> EditTask(Tasks task , int id)
            { 
                var tas = await dbcon.Tasks.FirstOrDefaultAsync(x => x.TasksID ==id);
                tas.Status = task.Status;
                tas.Description = task.Description;
                tas.Priority = task.Priority;
                tas.DeadLine = task.DeadLine;
                tas.ProjectID = task.ProjectID;
                tas.TeamMemberID = task.TeamMemberID;
                var project = await dbcon.Projects.FirstOrDefaultAsync(x => x.ProjectID == tas.ProjectID);
                dbcon.Tasks.Update( tas );
                await dbcon.SaveChangesAsync();
                return RedirectToAction("GetProjects" , "Project"); 
            }
    }
}
