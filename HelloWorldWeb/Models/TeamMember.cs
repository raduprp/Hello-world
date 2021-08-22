// <copyright file="TeamMember.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;

namespace HelloWorldWeb.Models
{
    [DebuggerDisplay("{Name}[{Id}]")]
    public class TeamMember
    {
        

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

    }


}