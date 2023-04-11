using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphicShootoutApp
{
    public abstract class Weapon : IShootable
    {

        // Fields

        private string _brand = "";

        // Properties

        // Methods

        public virtual string Shoot()
        {

        }

        public string ToString()
        {

        }

        public string Weapon(string brand)
        {

        }

        // Constructors



    }
}