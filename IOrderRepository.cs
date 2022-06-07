using PharmacyManagementSystemWebApi.Models;
using System.Collections.Generic;

namespace pharmacyManagementWebApiservice.Repository
{
    public interface IOrderRepository
    {
        OrderDetail Create(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetAll();

        OrderDetail GetOrder(int id);
        void DeleteOrder(int id);
        void UpdateOrder(OrderDetail orderDetail);
    }
}