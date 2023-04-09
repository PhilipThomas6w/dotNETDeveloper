using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPillarsApp;

public abstract class Animal                // This is an abstract class. It cannot be instantiated.
{
    private string _name;
    public string Kingdom { get; set; }

    public int Legs { get; set; } = 0;

    public DateTime Age { get; set; }

    public bool hasTail { get; set; }

    public abstract string Speak();         // This is an abstract method. You have to have this method, but how you implement it is up to you. 

    public virtual double Move()
    {
        return 0d;
    }


}

public class Dog : Animal
{
    public double Speed { get; set; } = 10;

    public Dog() : base()
    {

    }
    public override string Speak()
    {
        return "Woof!";
    }

    public override double Move()
    {
        return Speed;
    }
}

public class Corgi : Dog
{
    public int LegSize { get; set; } = 1;

    public override double Move()
    {
        return 0.1d;
    }
}

public class Cat : Animal
{

}

public class Bird : Animal
{

}