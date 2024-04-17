namespace ToledoCW.Services.Model.Notifications;

public class Notification
{
    private Notification()
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
    }

    public Notification(string key, string value, NotificationType type) : this()
    {
        Key = key;
        Value = value;
        Type = type;
    }

    public Guid Id { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    public DateTime Date { get; set; }

    public NotificationType Type { get; set; }

    public override string ToString()
    {
        var _strNotification = "";

        _strNotification += "Data: " + Date.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine;
        _strNotification += "Key: " + Key + Environment.NewLine;
        _strNotification += "Message: " + Value + Environment.NewLine;
        _strNotification += "".PadLeft(40, '=') + Environment.NewLine;

        return _strNotification;
    }
}