using Assesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entites;

namespace Assesment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext dbcon;

        public ProjectController(AppDbContext dbcon)
        {
            this.dbcon = dbcon;
        }
        public async Task<IActionResult> GetProjects()
        {
            var search = await dbcon.Projects.ToListAsync();
            return View(search);
        }
        public async Task<IActionResult> AddProject()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddProject(Project project)
        {
            await dbcon.Projects.AddAsync(project);
            await dbcon.SaveChangesAsync();
            return RedirectToAction("GetProjects");
        }

        public async Task<IActionResult> RemoveProject(int id)
        {
            var search = await dbcon.Projects.FirstOrDefaultAsync(x => x.ProjectID == id);
            dbcon.Projects.Remove(search);
            await dbcon.SaveChangesAsync();
            return RedirectToAction("GetProjects");
        }

        public async Task<IActionResult> EditProject(int id)
        {
            var search = await GetProjectByID(id);
            return View(search);
        }
        [HttpPost]
        public async Task<IActionResult> EditProject(Project project)
        {

            dbcon.Projects.Update(project);
            await dbcon.SaveChangesAsync();
            return RedirectToAction("GetProjects");

        }

        [HttpGet]
        public async Task<IActionResult> ProjectDetails(int id , Project project)
        {
            var search = await dbcon.Projects.Include(x => x.Tasks).ThenInclude(x => x.TeamMember).FirstOrDefaultAsync(x => x.ProjectID == id);
            return View(search);
        }


        public async Task<Project> GetProjectByID(int id)
        {
            var search = await dbcon.Projects.FirstOrDefaultAsync(x => x.ProjectID == id);
            return search;
        }


    }
}
