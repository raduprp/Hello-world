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
        private Mock<IBroadcastService> broadcastServiceMock = null;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            var bcService = GetBroadcastService();
            ITeamService teamService = new TeamService(bcService);
            TeamMember newTeamMember = new Models.TeamMember("George", timeService);

            // Act

            teamService.AddTeamMember(newTeamMember);

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
            Mock.Get(bcService).Verify(_ => _.NewTeamMemberAdded(It.IsAny<string>(), It.IsAny<int>()), Times.Once());

        }


        [Fact]
        public void DeleteTeamMemberFromTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService(GetBroadcastService());
            var targetTeamMember = teamService.GetTeamInfo().TeamMembers[1];
            int targetId = targetTeamMember.Id;
            //Act
            teamService.DeleteTeamMember(targetId);
            //Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService(GetBroadcastService());
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
            ITeamService teamService = new TeamService(GetBroadcastService());
            var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMemberName = "Boris";
            //Act
            teamService.DeleteTeamMember(memberToBeDeleted.Id);
            var id = teamService.AddTeamMember(new TeamMember(newMemberName, timeService));
            teamService.DeleteTeamMember(id);
            //Assert
            var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == "Boris");
            Assert.Null(member);
        }

        private void InitializeBroadcastServiceMock()
        {
            /*// https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            Mock<IClientProxy> hubAllClients = new Mock<IClientProxy>();
            Mock<IHubClients> hubClients = new Mock<IHubClients>();
            hubClients.Setup(_ => _.All).Returns(hubAllClients.Object);
            messageHubMock.SetupGet(_ => _.Clients).Returns(hubClientsMock.Object); */
             this.broadcastServiceMock = new Mock<IBroadcastService>();
        }

        private IBroadcastService GetBroadcastService()
        {
            if (broadcastServiceMock == null)
            {
                InitializeBroadcastServiceMock();
            }

            return broadcastServiceMock.Object;
        }






    }


}
