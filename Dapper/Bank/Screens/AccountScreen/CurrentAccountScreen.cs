using Bank.Models;
using Bank.Repositories;
using Bank.Shared;
using Bank.Shared.Enums;

namespace Bank.Screens.AccountScreen;

public static class CurrentAccountScreen
{
    private static User? User { get; set; } = new();
    public static void Load(User? user)
    {
        User = user;
        Console.Clear();
        Console.WriteLine("Informe a opção desejada:");
        Console.WriteLine("[1] - Depositar");
        Console.WriteLine("[2] - Sacar");
        Console.WriteLine("[3] - Pix");
        Console.WriteLine("[4] - Ver transações");
        Console.WriteLine("[5] - Encerrar");
        Console.Write("\n\u001b[32m> \u001b[0m");
        if (!byte.TryParse(Console.ReadLine(), out byte value))
        {
            Console.Clear();
            Console.WriteLine("\u001b[31mInforme um valor correto!\u001b[0m");
            Console.ReadKey();
            Load(User);
        }

        Targeting(value);
    }

    private static void Targeting(byte value)
    {
        switch (value)
        {
            case 1:
                Deposit();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                Console.Clear();
                Console.WriteLine("Encerrando...");
                Console.ReadKey();
                break;
            default:
                Console.Clear();
                Console.WriteLine("\u001b[31mInforme um valor correto!\u001b[0m");
                Console.ReadKey();
                Load(User);
                break;
        }
    }
    
    
    private static void Deposit()
    {
        Console.Clear();
        var repository = new Repository<Account>();
        Console.WriteLine("Informe o valor que você deseja depositar: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            Console.Clear();
            Console.WriteLine("\u001b[31mInforme um valor válido!\u001b[0m");
            Console.ReadKey();
            Load(User);
        }

        var accounts = repository.GetAll().Where(x => x.UserId == User?.Id);
        var current = accounts.FirstOrDefault(x => x.Id == (int)AccountTypes.CurrentAccount);

        if (current is null || User is null) return;
        current.Balance += value;
        repository.Update(current);
        
        var transaction = new Transaction
        {
            AccountId = current.Id,
            AccountUserId = User.Id,
            Type = (byte)TransactionType.Deposit,
            Value = value,
            Date = DateTime.Now,
            Message = $"Valor do deposito: {value:C} \nData do deposito: {DateTime.Now}"
        };
        var repositoryTransaction = new Repository<Transaction>();
        repositoryTransaction.Create(transaction);
        Console.WriteLine("Transação feita com sucesso...");
        Console.ReadKey();
    }
}
