using FactoryMethodExample.DrinkShop;

namespace FactoryMethodExample.Beverages
{
    public class Espresso : Beverage
    {
        public override string Name => "Espresso";

        public override void Prepare()
        {
            Console.WriteLine("Press the Espresso button..chug chug chug gurgle.");
        }

        public override void Serve()
        {
            Console.WriteLine("Pass the tiny cup of Espresso to the customer.");
        }
    }
}
