using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using HelloWorldWebMVC.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamServiceTests
    {
        private ITimeService timeService;
        private Mock<IHubContext<MessageHub>> messageHub = null;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService(GetMockedMessageHub());
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
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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

        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            Mock<IClientProxy> hubAllClients = new Mock<IClientProxy>();
            Mock<IHubClients> hubClients = new Mock<IHubClients>();
            hubClients.Setup(_ => _.All).Returns(hubAllClients.Object);
            messageHub = new Mock<IHubContext<MessageHub>>();

            messageHub.SetupGet(_ => _.Clients).Returns(hubClients.Object);
        }

        private IHubContext<MessageHub> GetMockedMessageHub()
        {
            if (messageHub == null)
            {
                InitializeMessageHubMock();
            }

            return messageHub.Object;
        }






    }


}