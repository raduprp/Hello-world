using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamMemberTests
    {
        private ITimeService timeService;


        public TeamMemberTests()
        {
            timeService = new FakeTimeService();
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

    internal class FakeTimeService : ITimeService
    {
        public DateTime GetNow()
        {
            return new DateTime(2021, 08, 11);
        }
    }
}