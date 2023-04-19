using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Decorators
{
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage _beverage;
        
        public CondimentDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string? Description() => _beverage.Description();

        public override decimal Cost() => _beverage.Cost();
    }
}
