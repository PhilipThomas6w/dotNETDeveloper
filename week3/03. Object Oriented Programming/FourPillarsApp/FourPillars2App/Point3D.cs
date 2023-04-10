namespace FourPillars2App;

public struct Point3D
{
    public int x, y, z;

    public Point3D(int x, int y, int z = 10)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public double distanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }



}
