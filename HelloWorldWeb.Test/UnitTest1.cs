using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.AddTeamMember("George");

            // Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);
            
        }
    }
}