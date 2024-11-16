using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Bridge
{

    public class EmailSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Enviando correo electrónico: {message}");
        }
    }

    public class SmsSender : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Enviando SMS: {message}");
        }
    }
}
