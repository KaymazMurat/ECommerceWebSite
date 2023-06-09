﻿using MKaymaz_ECommerce.Common.Models;
using System;

namespace MKaymaz_ECommerce.Web.UI.Infrastructure.Helpers
{
    public class CookieModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public GetAcceessTokenDto AcceessToken { get; set; }
    }
}
