public interface IPaymentStrategy
{
    void PaymentMethod(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void PaymentMethod(decimal amount)
    {
        Console.WriteLine($"Credit Payment : {amount}");    
    }
}

public class CashPayment : IPaymentStrategy
{
    public void PaymentMethod(decimal amount)
    {
        Console.WriteLine($"Cash Payment : {amount}");    
    }
}

public class CryptoPayment : IPaymentStrategy
{
    public void PaymentMethod(decimal amount)
    {
        Console.WriteLine($"Crypto Payment: {amount}");
    }
}

public class PaymentService
{
    private readonly IPaymentStrategy _paymentStrategy;

    public PaymentService(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        _paymentStrategy.PaymentMethod(amount);
    }
}

public class Program
{
    public static void Main()
    {
        var payment = new PaymentService(new CryptoPayment());
        payment.ProcessPayment(51);

        payment = new PaymentService(new CashPayment());
        payment.ProcessPayment(76);
    }
}