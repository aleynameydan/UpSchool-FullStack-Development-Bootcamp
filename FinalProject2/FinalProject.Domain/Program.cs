

using FinalProject.WebApi;

var order = new Order()
{
    Id = Guid.NewGuid(),
    RequestedAmount = 50,
    ProductCrawlType = ProductCrawlType.All,
};


var orderEvent = new OrderEvent()
{
    Id = Guid.NewGuid(),
    OrderId = order.Id,
    CreatedOn = DateTimeOffset.Now,
    Status = OrderStatus.BotStarted
};

order.OrderEvents = new List<OrderEvent>();

order.OrderEvents.Add(orderEvent);



