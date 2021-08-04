// <copyright file="TeamInfo.cs" company="Principal 33 Solutions">
// Copyright (c) Principal 33 Solutions. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace HelloWorldWeb.Models
{
    public class TeamInfo
    {
        public string Name { get; set; }

        public List<string> TeamMembers { get; set; }
    }
}