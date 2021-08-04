using HelloWorldWeb.Models;

namespace HelloWorldWebApp.Services
{
    public interface ITeamService
    {
        void AddTeamMember(string name);

        TeamInfo GetTeamInfo();
    }
}