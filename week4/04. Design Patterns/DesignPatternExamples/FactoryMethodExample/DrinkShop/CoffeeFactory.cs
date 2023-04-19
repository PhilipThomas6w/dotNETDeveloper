using FactoryMethodExample.Beverages;

namespace FactoryMethodExample.DrinkShop
{
    public class CoffeeFactory : DrinkMaker
    {
        public override Beverage? Brew(string type)
        {
            type = type.ToLower();

            switch(type)
            {
                case "espresso":
                    return new Espresso();
            }
            return null;
        }
    }
}
