﻿// <copyright file="HomeController.cs" company="Principal 33 Solutions">
// Copyright (c) Principal 33 Solutions. All rights reserved.
// </copyright>

using System.Diagnostics;
using HelloWorldWeb.Models;
using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            this.logger = logger;
            this.teamService = teamService;
        }

        [HttpPost]
        public void AddTeamMember(string name)
        {
            teamService.AddTeamMember(name);
        }

        [HttpGet]
        public int GetCount()
        {
            return teamService.GetTeamInfo().TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(teamService.GetTeamInfo());
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