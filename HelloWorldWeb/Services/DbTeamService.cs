using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        public DbTeamService(ApplicationDbContext context)
        {
            _context = context;     
        }
        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember() { Name = name};
            _context.Add(teamMember);
            _context.SaveChanges();
            return teamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember =_context.TeamMembers.Find(id);
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
            
        }

        public void EditTeamMember(int id, string name)
        {
            throw new NotImplementedException();
        }

        public TeamInfo GetTeamInfo()
        {


            TeamInfo teamInfo = new TeamInfo();
            teamInfo.Name = "Radu";
            teamInfo.TeamMembers = _context.TeamMembers.ToList();
            return teamInfo; 

            

        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
