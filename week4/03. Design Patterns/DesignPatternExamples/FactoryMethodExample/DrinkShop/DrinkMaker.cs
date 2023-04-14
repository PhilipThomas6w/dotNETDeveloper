using FactoryMethodExample.DrinkShop;

namespace FactoryMethodExample.DrinkShop
{
    public abstract class DrinkMaker
    {
        public Beverage? OrderDrink(string type)
        {
            Beverage? beverage = Brew(type);
            if (beverage != null)
            {
                beverage.Prepare();
                beverage.Serve();
            }
            return beverage;
        }

        public abstract Beverage? Brew(string type);
    }
}
