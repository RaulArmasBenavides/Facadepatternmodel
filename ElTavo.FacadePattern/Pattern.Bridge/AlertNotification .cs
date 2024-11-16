using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Bridge
{
    public class AlertNotification : Notification
    {
        public AlertNotification(INotificationSender sender) : base(sender) { }

        public override void Send(string message)
        {
            Console.WriteLine("Notificación de Alerta:");
            sender.Send(message);
        }
    }

    public class ReminderNotification : Notification
    {
        public ReminderNotification(INotificationSender sender) : base(sender) { }

        public override void Send(string message)
        {
            Console.WriteLine("Notificación de Recordatorio:");
            sender.Send(message);
        }
    }
}
