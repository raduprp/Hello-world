using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using System;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class TeamMemberTests
    {
        

        private Mock<ITimeService> timeMock;
       

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.GetNow()).Returns(new DateTime(2021, 08, 11));
           
        }

        [Fact]
        public void GettingAge()
        {
            //Assume
            InitializeTimeServiceMock();

            var timeService = timeMock.Object;
            var newTeamMember = new TeamMember("Radu", timeService);
            newTeamMember.BirthDate = new DateTime(1998, 12, 10);
            
            //Act
            int age = newTeamMember.getAge();

            //Assert
            timeMock.Verify(library => library.GetNow(), Times.AtMostOnce());

            Assert.Equal(22, age);

        }

    }

   
}