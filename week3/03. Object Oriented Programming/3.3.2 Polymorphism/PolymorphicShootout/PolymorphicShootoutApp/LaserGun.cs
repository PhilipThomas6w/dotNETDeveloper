namespace PolymorphicShootoutApp
{
    public class LaserGun : Weapon
    {
        // Fields

        // Properties

        // Constructors
        public LaserGun(string brand = "") : base(brand) { }

        // Methods

        public override string Shoot()
        {
            return $"Zing!! {base.Shoot()}";    // LaserGuns go "PewPew", just saying...
        }

    }
}