using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Strategy
{
    //public class PaymentProcessor
    //{
    //    public void ProcessPayment(string paymentMethod)
    //    {
    //        if (paymentMethod == "creditCard")
    //        {
    //            Console.WriteLine("Processing payment with Credit Card");
    //        }
    //        else if (paymentMethod == "paypal")
    //        {
    //            Console.WriteLine("Processing payment with PayPal");
    //        }
    //        else if (paymentMethod == "debitCard")
    //        {
    //            Console.WriteLine("Processing payment with DebitCard");
    //        }
    //        else if (paymentMethod == "bankTransfer")
    //        {
    //            Console.WriteLine("Processing payment with Bank Transfer");
    //        }
    //        else
    //        {
    //            throw new ArgumentException("Unknown payment method");
    //        }
    //    }



    //}

    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;

        public PaymentProcessor(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void Process(decimal amount)
        {
            _paymentStrategy.ProcessPayment(amount);
        }
    }

}
