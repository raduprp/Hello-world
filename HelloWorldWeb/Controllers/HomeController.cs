// <copyright file="HomeController.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System.Diagnostics;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        // private readonly TeamInfo teamInfo;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;
        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService, IBroadcastService broadcastService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
            this.broadcastService = broadcastService;
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        
        public int AddTeamMember(string name)

        {
            TeamMember newTeamMembeer = new TeamMember(name, timeService);
            var returnVal = teamService.AddTeamMember(newTeamMembeer);

            broadcastService.NewTeamMemberAdded(newTeamMembeer.Name, newTeamMembeer.Id);

            return returnVal;

        }

        [HttpDelete]
        
        public void DeleteTeamMember(int id)
        {
            this.teamService.DeleteTeamMember(id);
            broadcastService.TeamMemberDeleted(id);
            
        }

        [HttpPost]
        
        public void EditTeamMember(int id, string name)
        {
            this.teamService.EditTeamMember(id, name);

        }

        public IActionResult Index()
        {
            
            return this.View(this.teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Chat()
        {
            return this.View();
        }



    }
}