using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphicShootoutApp
{
    public class PlasmaRifle : Weapon
    {
        // Fields

        // Properties

        // Constructors
        public PlasmaRifle(string brand = "") : base(brand) { }

        // Methods
        public override string Shoot()
        {
            return $"Zzzhhmmm!! {base.Shoot()}";
        }

    }
}