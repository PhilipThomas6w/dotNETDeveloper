namespace FourPillarsApp;

public class Dog : Animal
{
    public double Speed { get; set; } = 10;

    public Dog()
    {
        
    }

    public override string Speak()
    {
        return "Woof!";
    }

    public override sealed double Move()
    {
        return Speed;
    }
}

public class Corgi : Dog
{
    public int LegSize { get; set; } = 1;

    public override string Speak()
    {
        return "Yap yap!";
    }

    //public override double Move(); // can only inherit from superclass because method is sealed
    //{
    //    return 0.1d;
    //}
}