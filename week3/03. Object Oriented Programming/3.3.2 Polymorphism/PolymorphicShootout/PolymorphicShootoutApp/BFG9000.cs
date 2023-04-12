namespace PolymorphicShootoutApp
{
    public class BFG9000 : Weapon
    {
        // Fields

        // Properties

        // Constructors
        public BFG9000(string brand = "") : base(brand) { }

        // Methods
        public override string Shoot()
        {
            return $"Dudududududu!! {base.Shoot()}";
        }

    }
}