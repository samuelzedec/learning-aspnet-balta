namespace Solid._04_ISP.Bad;

public interface IEmployee
{
    string Name { get; set; }
    void CalculateSalary();
    void CalculateBenefits();
}

public class FullTimeEmployee : IEmployee
{
    public string Name { get; set; }
    public void CalculateSalary()
    {
        Console.WriteLine("Calcular salario");
    }

    public void CalculateBenefits()
    {
        Console.WriteLine("Calcular beneficio");
    }
}

public class ContractEmployee : IEmployee
{
    public string Name { get; set; }
    public void CalculateSalary()
    {
        Console.WriteLine("Calcular Salario");
    }

    public void CalculateBenefits()
    {
        throw new NotImplementedException();
    }
}