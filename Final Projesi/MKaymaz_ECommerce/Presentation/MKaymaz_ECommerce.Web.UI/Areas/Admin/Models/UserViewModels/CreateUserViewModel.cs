using MKaymaz_ECommerce.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.UserViewModels
{
    public class CreateUserViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsAdmin { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
