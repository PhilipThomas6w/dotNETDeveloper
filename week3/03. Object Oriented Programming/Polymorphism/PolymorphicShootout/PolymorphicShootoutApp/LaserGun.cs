namespace PolymorphicShootoutApp
{
    public class LaserGun : Weapon
    {
        // Fields


        // Properties



        // Methods

        public override string Shoot()
        {
            return $"Zing!! {base.Shoot()}";
        }

        public string LaserGunl(string brand)
        {

        }

        // Constructors
    }
}