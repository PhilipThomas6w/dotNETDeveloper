namespace FourPillarsApp;

public class Park
{

    public int Swings { get; set; } = 0;

    public int Roundabouts { get; set; } = 0;

    public string Name { get; set; } = "";

    public string Location { get; set; } = "";

    public int Trees { get; set; } = 0;

    public Person ParkManager { get; set; } = new Person();

    public List<Person> People { get; set; } = new List<Person> { };

    public Park() { }

}