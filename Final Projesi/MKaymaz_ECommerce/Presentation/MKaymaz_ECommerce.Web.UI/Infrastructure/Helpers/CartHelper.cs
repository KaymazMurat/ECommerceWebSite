using MKaymaz_ECommerce.Common.Dtos.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MKaymaz_ECommerce.Web.UI.Infrastructure.Helpers
{
    public class CartHelper
    {
        public List<CartItemRequestDto> CartList;
        public CartHelper()
        {
            CartList = new List<CartItemRequestDto>();
        }

        #region Sepete Ekle
        public void AddCart(CartItemRequestDto item)
        {
                       
            if (!CartList.Any(x => x.Id == item.Id))
                CartList.Add(item);
            else
                this.IncreaseCart(item.Id);
        }
        #endregion

        #region Sepet Arttır
        public void IncreaseCart(Guid id)
        {
            CartItemRequestDto productVM = CartList.Find(x => x.Id == id);
            productVM.Quantity++;
        }
        #endregion

        #region Sepet Azalt
        public void DecreaseCart(Guid id)
        {
            CartItemRequestDto productVM = CartList.Find(x => x.Id == id);
            productVM.Quantity--;
            if (productVM.Quantity <= 0)
                this.RemoveCart(id);
        }
        #endregion

        #region Sepetten Sil
        public void RemoveCart(Guid id) => CartList.Remove(CartList.Find(x => x.Id == id));
        #endregion
    }
}
