namespace PolymorphicShootoutApp
{
    public abstract class Weapon : IShootable
    {

        // Fields

        private string _brand = "";

        // Properties

        // Constructors
        public Weapon(string brand)
        {
            _brand = brand;
        }

        // Methods
        public virtual string Shoot()
        {
            return "";
        }

        public override string ToString()
        {
            return _brand;
        }

    }
}