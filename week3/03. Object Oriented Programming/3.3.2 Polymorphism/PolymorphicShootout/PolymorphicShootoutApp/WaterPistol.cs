namespace PolymorphicShootoutApp
{
    public class WaterPistol : Weapon
    {
        // Fields

        // Properties

        // Constructors
        public WaterPistol(string brand = "") : base(brand) { }

        // Methods
        public override string Shoot()
        {
            return $"Squirt!! {base.Shoot()}";
        }

    }
}