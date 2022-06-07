using PharmacyManagementSystemWebApi.Models;
using System.Collections.Generic;

namespace pharmacyManagementWebApiservice.Repository
{
    public interface IOrdersRepostiory
    {
        IEnumerable<Order> GetAll();
        Order Create(Order order);

        IEnumerable<Order> GetOrders(int id);
    }
}