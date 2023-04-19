using FactoryMethodExample.DrinkShop;

namespace FactoryMethodExample.DrinkShop
{
    public class TeaFactory : DrinkMaker
    {
        public override Beverage? Brew(string type)
        {
            type = type.ToLower();

            switch(type)
            {
                case "fruit":
                    return new FruitTea();
            }
            return null;
        }
    }
}
