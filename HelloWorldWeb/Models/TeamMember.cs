// <copyright file="TeamMember.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Services;
using HelloWorldWebMVC.Services;
using System;

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        private static int idCount = 0;
        private readonly ITimeService timeService;
        public TeamMember(string name, ITimeService timeService)
        {
            this.timeService = timeService;
            this.Id = idCount;
            this.Name = name;
            idCount++;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int getAge()
        {
            var age = this.timeService.GetNow().Subtract(BirthDate).Days;
            age = age / 365;

            return age;
        }

    }
}