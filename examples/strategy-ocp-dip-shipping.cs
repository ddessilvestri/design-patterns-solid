public interface IShippingStrategy
{
    decimal CalculateShipping(decimal orderTotal);
}


public class StandardShipping : IShippingStrategy
{
    decimal CalculateShipping(decimal orderTotal) => 5.00m;
}

public class AirShipping : IShippingStrategy
{
    decimal CalculateShipping(decimal orderTotal) => 6.00m;
}

public class ShippingService
{
    private IShippingStrategy _shippingStrategy;

    public ShippingService(IShippingStrategy shippingStrategy)
    {
        _shippingStrategy = shippingStrategy;
    }

    public void ProcessOrder(decimal orderTotal)
    {
        decimal cost = _shippingStrategy.CalculateShipping(orderTotal);
        Console.WriteLine($"Shipping Cost: ${cost}");
    }
}


public class Program
{
    public static void Main()
    {
        var order = new ShippingService(new AirShipping());
        order.ProcessOrder(80);
    }
}