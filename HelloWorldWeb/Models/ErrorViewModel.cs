// <copyright file="ErrorViewModel.cs" company="Principal 33 Solutions">
// Copyright (c) Principal 33 Solutions. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
