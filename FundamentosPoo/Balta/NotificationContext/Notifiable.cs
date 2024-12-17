namespace Balta.NotificationContext;

public abstract class Notifiable
{
    public List<Notification> Notifications { get; set; } = new();
    public bool IsInvalid => Notifications.Any();
    
    /* ---------------------------------------------------------------------
     * Ao usar o .Any() sem parâmetro, ele irá verificar se há pelo menos
     * um único elemento na lista
     * ---------------------------------------------------------------------
     */
    
    public void AddNotification(Notification notification)
    {
        Notifications.Add(notification);
    }

    public void AddNotifications(IEnumerable<Notification> notifications)
    {
        Notifications.AddRange(notifications);
    }

}
