using MKaymaz_ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Model.Entities
{
    public class User : CoreEntity
    {
        // İlişkilerden dolayı içe sonsuz bir yapı oluşturulmuş oldu.
        public User()
        {
            CreatedUsers=new HashSet<User>();
            ModifiedUsers=new HashSet<User>();

            CreatedUserCategories=new HashSet<Category>();
            ModifiedUserCategories=new HashSet<Category>();

            CreatedUserBrands= new HashSet<Brand>();
            ModifiedUserBrands= new HashSet<Brand>();

            CreatedUserCarts= new HashSet<Cart>();
            ModifiedUserCarts= new HashSet<Cart>();

            CreatedUserCartItems= new HashSet<CartItem>();
            ModifiedUserCartItems= new HashSet<CartItem>();

            CreatedUserCurrentAccounts= new HashSet<CurrentAccount>();
            ModifiedUserCurrentAccounts= new HashSet<CurrentAccount>();

            CreatedUserLocations= new HashSet<Location>();
            ModifiedUserLocations= new HashSet<Location>();

            CreatedUserMembers= new HashSet<Member>();
            ModifiedUserMembers= new HashSet<Member>();

            CreatedUserProducts= new HashSet<Product>();
            ModifiedUserProducts= new HashSet<Product>();

            CreatedUserTowns=new HashSet<Town>();
            ModifiedUserTowns= new HashSet<Town>();

            CreatedUserCountries= new HashSet<Country>();
            ModifiedUserCountries= new HashSet<Country>();

            CreatedUserCurrencies= new HashSet<Currency>();
            ModifiedUserCurrencies= new HashSet<Currency>();

            CreatedUserFavouritedProducts= new HashSet<FavouritedProduct>();
            ModifiedUserFavouritedProducts = new HashSet<FavouritedProduct>();

            CreatedUserOrders= new HashSet<Order>();
            ModifiedUserOrders= new HashSet<Order>();

            CreatedUserMaillists= new HashSet<Maillist>();
            ModifiedUserMaillists = new HashSet<Maillist>();

            CreatedUserOrderDetails= new HashSet<OrderDetail>();
            ModifiedUserOrderDetails = new HashSet<OrderDetail>();

            CreatedUserOrderItems= new HashSet<OrderItem>();
            ModifiedUserOrderItems = new HashSet<OrderItem>();

            CreatedUserShippingAddresses= new HashSet<ShippingAddres>();
            ModifiedUserShippingAddresses = new HashSet<ShippingAddres>();

            CreatedUserOrderAddresses= new HashSet<OrderAddress>();
            ModifiedUserOrderAddresses = new HashSet<OrderAddress>();

            CreatedUserProductPrices= new HashSet<ProductPrice>();
            ModifiedUserProductPrices = new HashSet<ProductPrice>();

            CreatedUserProductImages= new HashSet<ProductImage>();
            ModifiedUserProductImages = new HashSet<ProductImage>();

            CreatedUserProductComments= new HashSet<ProductComment>();
            ModifiedUserProductComments = new HashSet<ProductComment>();
            Carts = new HashSet<Cart>();
            Orders=new HashSet<Order>();

            Products=new HashSet<Product>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public string LastIPAddress { get; set; }
        public DateTime? LastLogin { get; set; }

        public User CreatedUser { get; set; }
        public User ModifiedUser { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Product> CreatedUserProducts { get; set; }
        public ICollection<Product> ModifiedUserProducts { get; set; }

        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> ModifiedUsers { get; set; }

        public ICollection<Category> CreatedUserCategories { get; set; }
        public ICollection<Category> ModifiedUserCategories { get; set; }

        public ICollection<Brand> CreatedUserBrands { get; set; }
        public ICollection<Brand> ModifiedUserBrands { get; set; }

        public ICollection<Cart> CreatedUserCarts { get; set; }
        public ICollection<Cart> ModifiedUserCarts { get; set; }

        public ICollection<CartItem> CreatedUserCartItems { get; set; }
        public ICollection<CartItem> ModifiedUserCartItems { get; set; }

        public ICollection<Country> CreatedUserCountries { get; set; }
        public ICollection<Country> ModifiedUserCountries { get; set; }

        public ICollection<CurrentAccount> CreatedUserCurrentAccounts { get; set; }
        public ICollection<CurrentAccount> ModifiedUserCurrentAccounts { get; set; }

        public ICollection<Location> CreatedUserLocations { get; set; }
        public ICollection<Location> ModifiedUserLocations { get; set; }

        public ICollection<Member> CreatedUserMembers { get; set; }
        public ICollection<Member> ModifiedUserMembers { get; set; }

        

        public ICollection<Town> CreatedUserTowns { get; set; }
        public ICollection<Town> ModifiedUserTowns { get; set; }

        public ICollection<Currency> CreatedUserCurrencies { get; set; }
        public ICollection<Currency> ModifiedUserCurrencies { get; set; }

        public ICollection<FavouritedProduct> CreatedUserFavouritedProducts { get; set; }
        public ICollection<FavouritedProduct> ModifiedUserFavouritedProducts { get; set; }

        public ICollection<Order> CreatedUserOrders { get; set; }
        public ICollection<Order> ModifiedUserOrders { get; set; }

        public ICollection<Maillist> CreatedUserMaillists { get; set; }
        public ICollection<Maillist> ModifiedUserMaillists { get; set; }

        public ICollection<OrderDetail> CreatedUserOrderDetails { get; set; }
        public ICollection<OrderDetail> ModifiedUserOrderDetails { get; set; }

        public ICollection<OrderItem> CreatedUserOrderItems { get; set; }
        public ICollection<OrderItem> ModifiedUserOrderItems { get; set; }

        public ICollection<ShippingAddres> CreatedUserShippingAddresses { get; set; }
        public ICollection<ShippingAddres> ModifiedUserShippingAddresses { get; set; }

        public ICollection<OrderAddress> CreatedUserOrderAddresses { get; set; }
        public ICollection<OrderAddress> ModifiedUserOrderAddresses { get; set; }  
        
        public ICollection<ProductPrice> CreatedUserProductPrices { get; set; }
        public ICollection<ProductPrice> ModifiedUserProductPrices { get; set; } 
        
        public ICollection<ProductImage> CreatedUserProductImages { get; set; }
        public ICollection<ProductImage> ModifiedUserProductImages { get; set; }  
        
        public ICollection<ProductComment> CreatedUserProductComments { get; set; }
        public ICollection<ProductComment> ModifiedUserProductComments { get; set; }

    }
}
