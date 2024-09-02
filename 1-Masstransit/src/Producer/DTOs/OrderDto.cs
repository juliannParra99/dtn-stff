using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.DTOs
{
    public class OrderDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}