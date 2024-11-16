using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Bridge
{
    // Abstraction
    public abstract class Notification
    {
        protected INotificationSender sender;

        protected Notification(INotificationSender sender)
        {
            this.sender = sender;
        }

        public abstract void Send(string message);
    }
}
