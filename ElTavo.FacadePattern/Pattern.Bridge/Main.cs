using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear métodos de envío
            INotificationSender emailSender = new EmailSender();
            INotificationSender smsSender = new SmsSender();

            // Crear notificaciones con métodos de envío diferentes
            Notification alert = new AlertNotification(emailSender);
            Notification reminder = new ReminderNotification(smsSender);

            // Enviar mensajes
            alert.Send("¡Alerta de seguridad!");
            reminder.Send("No olvides tu cita mañana.");

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

}
