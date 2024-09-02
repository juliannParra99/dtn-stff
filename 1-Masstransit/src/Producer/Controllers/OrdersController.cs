using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Producer.DTOs;
using SharedModels; // Asegúrate de que este namespace sea correcto


namespace Producer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IPublishEndpoint _publishEndpoint;
        public OrdersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            await _publishEndpoint.Publish<OrderCreated>(new
            {
                Id = 1,
                orderDto.ProductName,
                orderDto.Quantity,
                orderDto.Price
            });

            return Ok();
        }
    }
}