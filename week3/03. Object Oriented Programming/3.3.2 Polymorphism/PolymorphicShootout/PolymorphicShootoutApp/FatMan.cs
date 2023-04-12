namespace PolymorphicShootoutApp
{
    public class FatMan: Weapon
    {

        // Constructors
        public FatMan(string brand = "") : base(brand) { }

        
        // Methods
        public override string Shoot()
        {
            return $"KABOOM!! {base.Shoot()}";
        }

    }
}