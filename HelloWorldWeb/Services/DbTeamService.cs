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
        public int AddTeamMember(TeamMember member)
        {
            _context.Add(member);
            _context.SaveChanges();
            return member.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember =_context.TeamMembers.Find(id);
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
            
        }

        public void EditTeamMember(int id, string name)
        {
            var teamMember = this._context.TeamMembers.Find(id);
            teamMember.Name = name;
            this._context.Update(teamMember);
            this._context.SaveChanges();
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
