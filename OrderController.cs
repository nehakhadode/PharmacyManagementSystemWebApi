using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystemWebApi.Models;
using pharmacyManagementWebApiservice.Dto;
using pharmacyManagementWebApiservice.Repository;

namespace pharmacyManagementWebApiservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var order = _orderRepository.GetAll();
            return Ok(order);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            var supplier = _orderRepository.GetOrder(id);
           
            return new OkObjectResult(supplier);
        }
        [HttpPost]
        public IActionResult Post(OrderDto orderDto)
        {
            var order = new OrderDetail
            {
                DrugId = orderDto.DrugId,
                Quantity = orderDto.Quantity,
                TotalAmount = orderDto.TotalAmount,
                OrderPrice = orderDto.OrderPrice,
            };
            var newOrder = _orderRepository.Create(order);
            return Created("Sucess", newOrder);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderDto orderDto)
        {
            var order = new OrderDetail
            {
                DrugId = orderDto.DrugId,
                Quantity = orderDto.Quantity,
                TotalAmount = orderDto.TotalAmount,
                OrderPrice = orderDto.OrderPrice,
            };
            _orderRepository.UpdateOrder(order);
            return new OkResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderRepository.DeleteOrder(id);
            return Ok();
        }

    }
}