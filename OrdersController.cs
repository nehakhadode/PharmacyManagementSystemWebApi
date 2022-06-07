using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystemWebApi.Models;
using pharmacyManagementWebApiservice.Dto;
using pharmacyManagementWebApiservice.Repository;

namespace pharmacyManagementWebApiservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepostiory _ordersRepository;

        public OrdersController(IOrdersRepostiory orderRepository)
        {
            _ordersRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var order = _ordersRepository.GetAll();
            return Ok(order);
        }
        [HttpPost]
        public IActionResult Post(AddOrders addOrder)
        {
            var order = new Order
            {
                OrderId = addOrder.OrderId,
                UserId = addOrder.UserId,
            };
            var newOrder = _ordersRepository.Create(order);
            return Created("Sucess", newOrder);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            var order = _ordersRepository.GetOrders(id);
            
            return new OkObjectResult(order);
        }
    }

}