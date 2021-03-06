// <copyright file="ITeamService.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(TeamMember newTeamMember);

        TeamInfo GetTeamInfo();

        void DeleteTeamMember(int index);

        void EditTeamMember(int id, string name);

        TeamMember GetTeamMemberById(int id);

        

        
    }
}