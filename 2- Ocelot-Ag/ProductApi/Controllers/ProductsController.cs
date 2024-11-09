using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { "Product 1", "Product 2", "Product 3" });
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok($"Product {id}");
        }
    }
}