using Balta.NotificationContext;
using Balta.SharedContext;
namespace Balta.SubscriptionContext;

public class Student : Base
{
    public string Name { get; set; }
    public string Email { get; set; }
    public User User { get; set; }
    public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);

    public void CreateSubscription<TKey>(TKey subscription) where TKey : Subscription
    {
        if (IsPremium)
        {
            AddNotification(new Notification("Premium", "O Aluno já tem uma assinatura ativo"));
            return;
        }
        Subscriptions.Add(subscription);
    } 
    
}
