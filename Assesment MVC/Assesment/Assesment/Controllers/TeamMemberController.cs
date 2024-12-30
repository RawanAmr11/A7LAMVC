using Assesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entites;

namespace Assesment.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext dbcon;

        public TeamMemberController(AppDbContext dbcon)
        {
            this.dbcon = dbcon;
        }
        public async Task<IActionResult> TeamMemberDetails(int id)
        {
            var mm = await dbcon.TeamMembers
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.TeamMemberID == id);
            return View(mm);
        }

        [HttpGet]
        public async Task<IActionResult> EditTeamMember(int id)
        {
            var search = await GetMemberByID(id);
            return View(search);
        }
        [HttpPost]
        public async Task<IActionResult> EditTeamMember(TeamMember teamMember)
        { 
            dbcon.TeamMembers.Update(teamMember);
            await dbcon.SaveChangesAsync();
            return RedirectToAction("GetProjects","Project");
        }
        public async Task<IActionResult> RemoveMember(int id)
        {
            var search = await GetMemberByID(id);
            dbcon.TeamMembers.Remove(search);
            await dbcon.SaveChangesAsync();
            return RedirectToAction("GetProjects", "Project");


        }
        public async Task<TeamMember> GetMemberByID(int id)
        {
            var search = await dbcon.TeamMembers.FirstOrDefaultAsync(x => x.TeamMemberID == id);
            return search;
        }

    }
}
