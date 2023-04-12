namespace PolymorphicShootoutApp;

public class Camera : IShootable
{
    private string _brand;

    public Camera(string brand)
    {
        _brand = brand;
    }

    public virtual string Shoot()
    {
        return "Cheese!!";
    }

    public override string ToString()
    {
        return _brand;
    }
}