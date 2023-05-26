namespace InheritanceLab;

public class Airplane : Vehicle
{
    private string _airline;

    public int Altitude { get; private set; }

    public Airplane(int capacity)
    {
        
    }

    public Airplane(int capacity, int speed, string airline)
    {
        
    }

    public void Ascend(int distance)
    {
        throw new NotImplementedException();
    }

    public void Descend(int distance)
    {
        throw new NotImplementedException();
    }

    public string Move()
    {
        throw new NotImplementedException();
    }

    public string Move(int times)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }


}