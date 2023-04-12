namespace PolymorphicShootoutApp;

public class Hunter : Person
{
    // Fields

    //private string _camera = "";

    // Properties

    public IShootable Shooter { get; set; }

    // Constructors

    public Hunter() { } 
    
    public Hunter(string fName, string lName, IShootable shooter) : base(fName, lName)
    {
        Shooter = shooter;
    }

    // Methods

    public string Shoot()
    {
        return Shooter.Shoot();
    }

    public override string ToString()
    {
        return $"{base.ToString()} {Shooter}";
    }

}