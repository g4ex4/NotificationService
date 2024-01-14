using System.Configuration;
using Notification.Interfaces;
using Notification.Models;

namespace Notification.Services
{
    public class NotificationService
    {
        private readonly INotificationService nameNotificationService;
        private readonly INotificationService emailNotificationService;
        private readonly INotificationService phoneNotificationService;

        public NotificationService(
            INotificationService nameNotificationService,
            INotificationService emailNotificationService,
            INotificationService phoneNotificationService)
        {
            this.nameNotificationService = nameNotificationService;
            this.emailNotificationService = emailNotificationService;
            this.phoneNotificationService = phoneNotificationService;
        }

        public void NotifyUserChanges(User user)
        {
            if (!string.IsNullOrEmpty(user.Name))
                ScheduleNotification(nameNotificationService, $"User {user.Name} has updated their Name.");

            if (!string.IsNullOrEmpty(user.Email))
                ScheduleNotification(emailNotificationService, $"User {user.Name} has updated their Email.");

            if (!string.IsNullOrEmpty(user.Phone))
                ScheduleNotification(phoneNotificationService, $"User {user.Name} has updated their Phone.");
        }

        private void ScheduleNotification(INotificationService notificationService, string message)
        {
            int notificationTime = GetNotificationTime(notificationService.GetType().Name + "Time");
            Thread.Sleep(notificationTime);
            notificationService.Notify(message);
        }

        private int GetNotificationTime(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key];
                if (int.TryParse(value, out int result))
                {
                    return result;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
