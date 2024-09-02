using Consumer;
using MassTransit;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    //for dev porpouses
    cfg.Host("localhost", "/", h =>
    {
        h.Username("user");
        h.Password("mypass");
    });

    cfg.ReceiveEndpoint("order-created-event", e =>
    {
        e.Consumer<OrderCreatedConsumer>();
    });
});

await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}
