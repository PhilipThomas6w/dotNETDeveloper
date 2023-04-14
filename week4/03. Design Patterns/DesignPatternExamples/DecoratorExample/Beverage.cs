using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample
{
    public abstract class Beverage
    {
        protected string? _description = "No beverage";

        public abstract string? Description();

        public abstract decimal Cost();
    }
}
