using Notification.Models;
using Notification.Services;

var pushNotificationService = new PushNotificationService();
var emailNotificationService = new EmailNotificationService();
var phoneNotificationService = new PhoneNotificationService();

var notificationService = new NotificationService(
    pushNotificationService,
    emailNotificationService,
    phoneNotificationService
);

var user = new User { Name = "Test Testov", Email = "test@example.com", Phone = "+123456789" };

notificationService.NotifyUserChanges(user);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
    await Task.Delay(1000);
}