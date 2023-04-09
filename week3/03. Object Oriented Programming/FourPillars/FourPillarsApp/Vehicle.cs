using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;

namespace FourPillarsApp
{
    public class Vehicle
    {
        private int _capacity;
        private int _numPassengers;

        public int NumPassengers { get; set; }

        public int Position { get; set; }

        public int Speed { get; }

        public string Move()
        {
            throw new System.NotImplementedException();
        }

        public string Move(int times)
        {
            throw new System.NotImplementedException();
        }

        public string ToString()
        {
            throw new System.NotImplementedException();
        }

        public Vehicle()
        {
            
        }

        public Vehicle(int capacity, int speed = 10)
        {
            _capacity = capacity;
            Speed = 10;

        }
    }

    public class Airplane : Vehicle
    {
        private string _airline;

        public int Altitude { get; set; }

        public Airplane(int capacity) : base(capacity)
        {
            _capacity = capacity;
        }

        public Airplane(int capacity, int speed, string airline) : base(capacity, speed = 10)
        {
            _capacity = capacity;
            _speed = speed;
            _airline = airline;
        }

        public void Ascend(int distance)
        {
            Altitude += distance;
        }

        public void Descend(int capacity)
        {
            Altitude -= distance;
            if (Altitude < 0)
            {
                Altitude = 0;
            }
        }

        public override string Move()
        {
            return $"{base.Move()} at an altitude of {Altitude} metres.";
        }

        public string Move(int times)
        {
           return $"{base.Move(times)} at an altitude of {Altitude} metres.";
        }

        public override string ToString()
        {
            return $"Thank you for flying {_airline}: (base.ToString()}, Altitude: {Altitude}.";
        }
    }
}