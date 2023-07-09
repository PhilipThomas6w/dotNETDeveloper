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
    public int Speed { get; }

    public Vehicle()
    {
        
    }

    public Vehicle(int capacity, int speed = 10)
    {
        _capacity = capacity;
        Speed = speed;
        Position = 0;
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

    public override string ToString()
    {
        return $"{base.ToString()} capacity: {_capacity} passengers: {NumPassengers} speed: {Speed} position: {Position}";
    }
}