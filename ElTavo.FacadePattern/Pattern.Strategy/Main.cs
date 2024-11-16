using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentStrategy creditCard = new CreditCardPayment();
            IPaymentStrategy payPal = new PayPalPayment();
            IPaymentStrategy bankTransfer = new BankTransferPayment();

            // Procesador de pagos
            PaymentProcessor processor = new PaymentProcessor(creditCard);

            // Procesar pagos
            processor.Process(100.00m); // Pago con tarjeta de crédito

            // Cambiar estrategia en tiempo de ejecución
            processor.SetStrategy(payPal);
            processor.Process(200.00m); // Pago con PayPal

            processor.SetStrategy(bankTransfer);
            processor.Process(300.00m); // Pago con transferencia bancaria
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
