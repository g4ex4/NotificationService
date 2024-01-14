using Notification.Interfaces;

namespace Notification.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email Notification: {message}");
        }
    }
}
