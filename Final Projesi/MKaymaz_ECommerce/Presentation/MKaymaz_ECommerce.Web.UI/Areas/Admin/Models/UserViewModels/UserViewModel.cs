using MKaymaz_ECommerce.Common.Enums;
using MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MKaymaz_ECommerce.Web.UI.Areas.Admin.Models.UserViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Products = new HashSet<ProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => LastName != null ? FirstName + " " + LastName : FirstName;
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastIPAddress { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }

    }
}
