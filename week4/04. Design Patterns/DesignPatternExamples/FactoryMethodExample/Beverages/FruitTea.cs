namespace FactoryMethodExample.DrinkShop
{
    public class FruitTea : Beverage
    {
        public override string Name => "Fruit Tea";

        public override void Prepare()
        {
            Console.WriteLine("Putting fruit tea bag in mug " +
                "and pouring on boiling water.");
        }

        public override void Serve()
        {
            Console.WriteLine("Pass the fruit tea to the customer.");
        }
    }
}
