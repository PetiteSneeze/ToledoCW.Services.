using System.ComponentModel;

namespace ToledoCW.Services.Model.Notifications;

public enum NotificationType
{
    [Description("Error")] Error,

    [Description("Warning")] Warning,

    [Description("Information")] Information
}