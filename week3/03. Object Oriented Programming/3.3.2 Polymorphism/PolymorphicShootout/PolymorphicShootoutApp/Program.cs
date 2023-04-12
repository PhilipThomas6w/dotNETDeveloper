namespace PolymorphicShootoutApp;

public class Program
{
    static void Main()
    {
        List<Weapon> weapons = new() { new LaserGun("Blaster"), new WaterPistol("Super Soacker"), new PlasmaRifle("Spartan Killer"), new FatMan("PipBoy"), new BFG9000("Doom")  }; 

        foreach (Weapon weapon in weapons)
        {
            
        }
       
    }
}