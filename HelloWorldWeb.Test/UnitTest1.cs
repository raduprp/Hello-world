using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTests
    {
        private ITeamService teamService;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();


            // Act

            TeamMember member = new TeamMember();
            member.Name = "Patrick";
            teamService.AddTeamMember(member);

            // Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);

        }


        [Fact]
        public void DeleteTeamMemberFromTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            var targetTeamMember = teamService.GetTeamInfo().TeamMembers[1];
            int targetId = targetTeamMember.Id;
            //Act
            teamService.DeleteTeamMember(targetId);
            //Assert
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            var targetTeamMember = teamService.GetTeamInfo().TeamMembers[0];
            var memberId = targetTeamMember.Id;
            //Act
            teamService.EditTeamMember(memberId, "NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(memberId).Name);
        }
    }


}