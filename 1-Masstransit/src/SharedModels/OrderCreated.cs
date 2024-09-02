using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedModels
{
    public interface OrderCreated
    {
        int Id { get; set; }
        string ProductName { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
    }
}