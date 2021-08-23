// <copyright file="TeamService.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorldWeb.Models;
using HelloWorldWebMVC.Services;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        private ITimeService timeService;

        private readonly IHubContext<MessageHub> messageHub;

        public TeamService(IHubContext<MessageHub> messageHubContext)
        {
            this.messageHub = messageHubContext;


            this.teamInfo = new TeamInfo
            {
                Name = "Team 1",
                TeamMembers = new List<TeamMember>(),
            };

            this.AddTeamMember("Sorina",(TimeService)timeService);
            this.AddTeamMember("Ema",(TimeService)timeService);
            this.AddTeamMember("Patrick",(TimeService)timeService);
            this.AddTeamMember("Tudor",(TimeService)timeService);
            this.AddTeamMember("Radu",(TimeService)timeService);

            this.messageHub = messageHubContext;

        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {

            Console.WriteLine(id);
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public int AddTeamMember(string name, ITimeService timeService)
        {
            TeamMember member = new TeamMember(name, timeService);
            this.teamInfo.TeamMembers.Add(member);
            this.messageHub.Clients.All.SendAsync("NewTeamMemberAdded", name, member.Id);
            return member.Id;

        }



        public void DeleteTeamMember(int index)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(index));
        }


        

        public void EditTeamMember(int id, string name)
        {
            TeamMember member = GetTeamMemberById(id);
            member.Name = name;
        }




    }
}