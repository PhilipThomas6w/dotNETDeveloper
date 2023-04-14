using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Beverages
{
    internal class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            _description = "House Blend";
        }

        public override decimal Cost()
        {
            return 0.89M;
        }

        public override string? Description()
        {
            return _description;
        }
    }
}
