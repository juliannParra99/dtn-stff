using System;
using System.Text.Json;
using System.Threading.Tasks;
using MassTransit;
using SharedModels;

namespace Consumer
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            var jsonMessage = JsonSerializer.Serialize(context.Message);
            Console.WriteLine($"OrderCreated message: {jsonMessage}");

            return Task.CompletedTask;
        }
    }
}
