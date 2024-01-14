using Notification.Interfaces;

namespace Notification.Services
{
    public class PhoneNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Phone Notification: {message}");
        }
    }
}
