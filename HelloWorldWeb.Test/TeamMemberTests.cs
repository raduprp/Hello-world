using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamMemberTests
    {
        [Fact]
        public void GettingAge()
        {
            //Assume
            ITeamService teamService = new TeamService();
            var newTeamMember = new TeamMember("Emma");
            newTeamMember.BirthDate = new DateTime(1998, 4, 22);

            //Act
            int age = newTeamMember.getAge();

            //Assert
            Assert.Equal(23, age);

        }

    }
}