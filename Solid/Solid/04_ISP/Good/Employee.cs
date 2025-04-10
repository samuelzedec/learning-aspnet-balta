using Solid._04_ISP.Bad;

namespace Solid._04_ISP.Good;

public interface IEmployee
{
    public string Name { get; set; }
}

public interface ISalaryCalculator
{
    void CalculateSalary();
}

public interface IBenefitsCalculator
{
    void CalculateBenefits();
}

public class FullTimeEmployee : IEmployee, ISalaryCalculator, IBenefitsCalculator
{
    public string Name { get; set; }
    public void CalculateSalary()
    {
        throw new NotImplementedException();
    }

    public void CalculateBenefits()
    {
        throw new NotImplementedException();
    }
}

public class ContractEmployee : IEmployee, ISalaryCalculator
{
    public string Name { get; set; }
    public void CalculateSalary()
    {
        throw new NotImplementedException();
    }
}