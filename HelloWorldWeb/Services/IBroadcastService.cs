// <copyright file="TeamService.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int id);
        void TeamMemberDeleted(int id);

        void TeamMemberEdit(int id, string name);
    }
}