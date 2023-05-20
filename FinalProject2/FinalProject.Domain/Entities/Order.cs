namespace FinalProject.WebApi;

public class Order
{
    public Guid Id { get; set; }

    //kaç tane ürün kazınmak istendiği?
    public int RequestedAmount { get; set; }

    //biz kaç tane kazıyabildik?
    public int TotalFoundAmount { get; set; }
    
    //kazınacak ürünlerin tipleri -- enum halinde
    public ProductCrawlType ProductCrawlType { get; set; }
    
    public ICollection<OrderEvent> OrderEvents { get; set; } //BotStarted

    public ICollection<Product> Products { get; set; } // her siparişin birden fazla product var

    public DateTimeOffset CreatedOn { get; set; }
}