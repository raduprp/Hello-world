// <copyright file="HomeController.cs" company="Principal 33 Solutions">
// Copyright (c) Principal 33 Solutions. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly TeamInfo teamInfo;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
            this.teamInfo = new TeamInfo
            {
            Name = "Team1",
            TeamMembers = new List<string>(),
            };

            this.teamInfo.TeamMembers.AddRange(new string[] { "Fineas", "Emma", "Patrick", "Tudor", "Radu P." });
    }

        [HttpPost]
        public void AddTeamMember(string name)
        {
            this.teamInfo.TeamMembers.Add(name);
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamInfo.TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(this.teamInfo);
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
    }
}
