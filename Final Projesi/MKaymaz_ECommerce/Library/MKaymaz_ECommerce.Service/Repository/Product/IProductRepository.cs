using MKaymaz_ECommerce.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.Product
{
    public interface IProductRepository :IRepository<EF.Product>
    {
    }
}
