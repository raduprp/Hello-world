using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamMemberTests
    {
        private ITimeService timeService;


        public TeamMemberTests()
        {
            var mock = new Mock<ITimeService>();
            mock.Setup(_=>_.GetNow()).Returns(new DateTime(2021,08,11));
            timeService = mock.Object;
        }
        [Fact]
        public void GettingAge()
        {
            //Assume
            ITeamService teamService = new TeamService();
            var newTeamMember = new TeamMember("Emma", timeService);
            newTeamMember.BirthDate = new DateTime(1998, 4, 22);

            //Act
            int age = newTeamMember.getAge();

            //Assert
            Assert.Equal(23, age);

        }

    }

   
}