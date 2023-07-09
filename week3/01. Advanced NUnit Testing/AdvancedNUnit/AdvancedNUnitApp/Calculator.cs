namespace AdvancedNUnitApp;

public class Calculator
{
    public double Num1 { get; set; }
    public double Num2 { get; set; }
    public double Add()
    {
        return Num1 + Num2;
    }

    public bool IsDivisible()
    {
        return Num1 % Num2 == 0;
    }
}