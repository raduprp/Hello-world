using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Test
{
    public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToAspNetString()
        {
            //Assume

            string herokuConnectionString = "postgres://lzbgxpkfvfnhwb:ffbf205079506209b9d4c6eadc303b84c88bd557c531ce531312ee4fdf517fc1@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/d9vulauagonmn6";

            //Act

            string aspnetConnectionString = Startup.ConvertHerokuStringToAspnetString(herokuConnectionString);


            //Assert
            Assert.Equal("Host=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Database=d9vulauagonmn6;User Id=lzbgxpkfvfnhwb;Password=ffbf205079506209b9d4c6eadc303b84c88bd557c531ce531312ee4fdf517fc1;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;", aspnetConnectionString);

        }
    }
}
