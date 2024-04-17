using ToledoCW.Services.Model.Notifications;

namespace ToledoCW.Services.Services;

public interface INotificationService
{
    void Handle(Notification notification, CancellationToken cancellationToken);

    void NewNotification(string key, string message, NotificationType type);

    IEnumerable<Notification> GetAll();

    void Clear();

    IEnumerable<Notification> GetAllErrors();

    bool HasNotifications();

    bool HasNotificationsErrors();
}