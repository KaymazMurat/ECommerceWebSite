using MKaymaz_ECommerce.Core.Repository;
using EF = MKaymaz_ECommerce.Model.Entities;

namespace MKaymaz_ECommerce.Service.Repository.OrderDetail
{
    public interface IOrderDetailRepository : IRepository<EF.OrderDetail>
    {
    }
}
