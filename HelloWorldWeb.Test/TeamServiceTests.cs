using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using HelloWorldWebMVC.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTests
    {
        private ITimeService timeService;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();
            ITimeService timeService = new TimeService();

            // Act

            teamService.AddTeamMember("George", timeService);

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

        [Fact]
        public void CheckIdProblem()
        {
            //Asume
            ITeamService teamService = new TeamService();
            var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMemberName = "Boris";
            //Act
            teamService.DeleteTeamMember(memberToBeDeleted.Id);
            var id = teamService.AddTeamMember(newMemberName, timeService);
            teamService.DeleteTeamMember(id);
            //Assert
            var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == "Boris");
            Assert.Null(member);
        }

       


    }


}