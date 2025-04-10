namespace Solid._02_OCP.Good;

public enum EProductType
{
    Eletronics = 1,
    Health = 2,
    Beauty = 3,
    Fashion = 4
}

public abstract class Discount
{
    public abstract decimal Calculate(decimal price);
}

public class EletronicsDiscount : Discount
{
    public override decimal Calculate(decimal price)
        => price * 0.2m;
}

public class HealthDiscount : Discount
{
    public override decimal Calculate(decimal price)
        => price * 0.3m;
}

public class BeautyDiscount : Discount
{
    public override decimal Calculate(decimal price)
        => price * 0.4m;
}

public class FashionDiscount : Discount
{
    public override decimal Calculate(decimal price)
        => price * 0.5m;
}