using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Decorators
{
    public class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage) : base(beverage)
        {
        }

        public override decimal Cost() => _beverage.Cost() + 0.15M;

        public override string Description() => base.Description() + ", Soy";
    }
}
