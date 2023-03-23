using MKaymaz_ECommerce.Common.Dtos.Base;
using MKaymaz_ECommerce.Common.Dtos.Cart;
using MKaymaz_ECommerce.Common.Dtos.Product;
using MKaymaz_ECommerce.Common.Models;
using System;
using System.Collections.Generic;

namespace MKaymaz_ECommerce.Common.Dtos.User
{
    public class UserResponseDto :BaseDto
    {
        public UserResponseDto()
        {
            Products=new HashSet<ProductResponseDto>();
            Carts=new HashSet<CartResponseDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastIPAddress { get; set; }
        public DateTime? LastLogin { get; set; }

        public DateTime? CreatedDate { get; set; }
        public bool IsAdmin { get; set; }

        public GetAcceessTokenDto AcceessToken { get; set; }

        public ICollection<ProductResponseDto> Products { get; set; }
        public ICollection<CartResponseDto> Carts { get; set; }
    }
}
