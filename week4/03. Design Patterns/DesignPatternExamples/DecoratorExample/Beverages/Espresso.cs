using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Beverages
{
    public class Espresso : Beverage
    {
        public Espresso()
        {
            _description = "Espresso";
        }

        public override decimal Cost()
        {
            return 1.99M;
        }
        public override string? Description()
        {
            return _description;
        }
    }
}
