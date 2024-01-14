using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Interfaces;

namespace Notification.Services
{
    public class PushNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Push Notification: {message}");
        }
    }
}
