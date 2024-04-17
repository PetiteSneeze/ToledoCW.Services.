using ToledoCW.Services.Model.Notifications;

namespace ToledoCW.Services.Services;

public sealed class NotificationService : INotificationService
{
    private List<Notification> _Notifications;

    public NotificationService()
    {
        _Notifications = new List<Notification>();
    }

    public void Handle(Notification notification, CancellationToken cancellationToken)
    {
        _Notifications.Add(notification);
    }

    public void NewNotification(string key, string message, NotificationType type)
    {
        Handle(new Notification(key, message, type), default);
    }

    public void Clear()
    {
        _Notifications.Clear();
    }

    public IEnumerable<Notification> GetAll()
    {
        return _Notifications;
    }

    public IEnumerable<Notification> GetAllErrors()
    {
        return _Notifications.Where(x => x.Type is NotificationType.Error);
    }

    public bool HasNotifications()
    {
        return _Notifications.Any(x => x.Type != NotificationType.Information);
    }

    public bool HasNotificationsErrors()
    {
        return _Notifications.Any(x => x.Type == NotificationType.Error);
    }
}