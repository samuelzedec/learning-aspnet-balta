namespace Balta.NotificationContext;

/* -------------------------------------------------------------------
 * Nessa parte de notificações já existe um pacote feito para isso
 * Ela está um pacote chamado Flunt criado por André Baltieri
 * -------------------------------------------------------------------
 */
public sealed class Notification
{
    public Notification() {}

    public Notification(string property, string message)
    {
        Property = property;
        Message = message;
    }
    
    public string Property { get; set; }
    public string Message { get; set; }
}

