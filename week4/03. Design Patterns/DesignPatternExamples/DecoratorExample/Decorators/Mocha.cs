using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Decorators
{
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage)
        {
        }

        public override decimal Cost() => _beverage.Cost() + 0.20M;

        public override string? Description() => base.Description() + ", Mocha";
    }
}
