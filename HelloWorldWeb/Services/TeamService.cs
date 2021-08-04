using HelloWorldWeb.Models;
using System.Collections.Generic;

namespace HelloWorldWebApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<string>(new string[]
               {
                    "Patrick",
                    "Fineas",
                    "Emma",
                    "Tudor",
                    "Radu P.",
                    
               }),
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public void AddTeamMember(string name)
        {
            teamInfo.TeamMembers.Add(name);
        }
    }
}
