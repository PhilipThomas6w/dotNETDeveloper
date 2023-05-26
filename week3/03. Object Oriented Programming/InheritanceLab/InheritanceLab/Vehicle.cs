using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceLab;

public class Vehicle
{
    private int _capacity;
    private int _numPassengers;

    public int NumPassengers { get; set; }
    public int Position { get; set; }

    public Vehicle()
    {
        
    }

    public Vehicle(int capacity, int speed = 10)
    {
        
    }

    public int Speed { get; }

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