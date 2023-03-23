using MKaymaz_ECommerce.Core.Repository;
using EF = MKaymaz_ECommerce.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Service.Repository.CartItem
{
    public interface ICartItemRepository:IRepository<EF.CartItem>
    {
    }
}
