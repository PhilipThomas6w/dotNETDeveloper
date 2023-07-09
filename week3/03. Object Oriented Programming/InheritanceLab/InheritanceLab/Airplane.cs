namespace InheritanceLab;

public class Airplane : Vehicle
{
    private string _airline;

    public int Altitude { get; private set; }

    public Airplane(int capacity): base(capacity)
    {
        _airline = "";
    }

    public Airplane(int capacity, int speed, string airline): base(capacity, speed)
    {
        _airline = airline;
    }

    public void Ascend(int distance)
    {
        Altitude += distance;
    }

    public void Descend(int distance)
    {
        if (Altitude - distance == 0)
        {
            Console.WriteLine("You have crashed!");
        }
        else Altitude -= distance;
    }

    public string Move()
    {
        return $"{base.Move()} at an altitude of {Altitude} metres.";
    }

    public string Move(int times)
    {
        return $"{base.Move(times)} at an altitude of {Altitude} metres.";
    }

    public override string ToString()
    {
        return $"Thank you for flying {_airline}: {base.ToString()} altitude: {Altitude}.";
    }


}