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

        private readonly IBroadcastService broadcastService;

        private ITimeService timeService;





        public TeamService(IBroadcastService broadcastService)
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team1",
                TeamMembers = new List<TeamMember>(),
            };
            teamInfo.TeamMembers.Add(new TeamMember("Sorina", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Ema", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Radu", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Patrick", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Tudor", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Fineas", timeService));

            
            this.broadcastService = broadcastService;
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

        public int AddTeamMember(TeamMember newTeamMember)
        {
            teamInfo.TeamMembers.Add(newTeamMember);
            
            broadcastService.NewTeamMemberAdded(newTeamMember.Name, newTeamMember.Id);

            return newTeamMember.Id;
        }



        public void DeleteTeamMember(int index)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(index));
            this.broadcastService.TeamMemberDeleted(index);
        }


        

        public void EditTeamMember(int id, string name)
        {
            TeamMember member = GetTeamMemberById(id);
            member.Name = name;
        }




    }
}