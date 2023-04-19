namespace FactoryMethodExample.DrinkShop
{
    public abstract class Beverage
    {
        public abstract void Prepare();
        public abstract void Serve();
        public abstract string Name { get; }
    }
}
