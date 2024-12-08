using Balta.NotificationContext;
namespace Balta.SharedContext;

public class Base : Notifiable
{
    public Base()
    {
        Id = Guid.NewGuid();
        /* -------------------------------------------------------------------------------------------------------
         * Ao usar o new Guid(), um GUID vazio será gerado,
         * contendo apenas zeros: "00000000-0000-0000-0000-000000000000".
         * Já ao usar o método estático .NewGuid() da classe Guid, será gerado um GUID único e aleatório,
         * com valores diferentes de zero.
         * -------------------------------------------------------------------------------------------------------
         */
    }

    public Guid Id { get; set; }

}
