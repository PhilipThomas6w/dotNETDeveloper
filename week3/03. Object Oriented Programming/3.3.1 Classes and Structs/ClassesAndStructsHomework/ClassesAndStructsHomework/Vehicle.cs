namespace ClassesAndStructsHomework;

public class Vehicle
{
    private int _capacity;
    private int _numPassengers;


    // NumPassengers has public get and set but the vehicle cannot carry a) more passengers then capacity b) negative number of passengers
    public int NumPassengers {
        get
        {
            return _numPassengers;
        }
        set
        {
            if (value > _capacity)
            {
                throw new ArgumentException("Number of passengers cannot exceed capacity");
            }
            else if (value < 0)
            {
                throw new ArgumentException("Number of passengers cannot be less than 0");
            }
            else
            {
                _numPassengers = value;
            }
        }
    }

    // The Position property should have a public get and private set
    public int Position { get; private set; }

    // The Speed property should have a public get and init set
    public int Speed { get; init; } = 10;

    public Vehicle()
    {
        
    }
    
    public Vehicle(int capacity, int speed = 10)
    {
        _capacity = capacity;
        Speed = speed;
    }

    public string Move()
    {
        Position += Speed;
        return $"Moving along";



    }
    
    public string Move(int times)
    {
        Position += Speed * times;
        return $"Moving along {times} times";
    }
    
    







}