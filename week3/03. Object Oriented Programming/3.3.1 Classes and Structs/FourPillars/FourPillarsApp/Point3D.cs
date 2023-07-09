namespace FourPillarsApp;

public struct Point3D
{
    public int x, y, z; // variables of the same type can be declared in series if you aren't initializing them

    public Point3D(int x, int y, int z = 10)
    {
        this.x = x;     // this.x means "x in this class". If we had just used x, it would be local to this scope.
        this.y = y;
        this.z = z;
    }

    public double distanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }



}