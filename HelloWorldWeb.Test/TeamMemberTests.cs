using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
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


        [Fact]
        public void DeleteTeamMemberFromTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.DeleteTeamMember(3);
            //Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
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
            var id = teamService.AddTeamMember(newMemberName);
            teamService.DeleteTeamMember(id);
            //Assert
            var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == "Boris");
            Assert.Null(member);
        }

        [Fact]
        public void TestGetAgeEqual()
        {
            // Assume
            TeamMember teamMember = new TeamMember("Ioan");
            teamMember.BirthDate = new DateTime(2000, 01, 01);
            int expectedAge = 21;

            // Act
            int computedAge = teamMember.getAge();

            // Assert
            Assert.Equal(expectedAge, computedAge);
        }

        [Fact]
        public void TestGetAgeNotEqual()
        {
            // Assume
            TeamMember teamMember = new TeamMember("Ioan");
            teamMember.BirthDate = new DateTime(2000, 01, 01);
            int expectedAge = 1;

            // Act
            int computedAge = teamMember.getAge();

            // Assert
            Assert.NotEqual(expectedAge, computedAge);
        }


    }


}
