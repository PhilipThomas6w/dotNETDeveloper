namespace CollectionsApp;

public class Person
{
    // Fields

    private string _firstName;
    private string _lastName;

    // Properties


    private int _age = 18;
    public int Age
    {
        get { return _age; }
        set { if (value >= 0) _age = value; }
    }

    public double Height { get; set; } = 180;

    // Methods

    public string GetFullName()
    {
        return $"{_firstName} {_lastName}";
    }

    public string GetFullName(string title)
    {
        //return $"{title} {_firstName} {_lastName}";
        return $"{title} {GetFullName()}";
    }

    public override string ToString()
    {
        return $"{base.ToString()} _firstName: {_firstName}, _lastName: {_lastName}, Age: {Age}, Height: {Height} cm, ";
    }

    // Constructors

    public Person(string fName, string lName)
    {
        _firstName = fName;
        _lastName = lName;
    }

    public Person(string fName, string lName, int age) : this(fName, lName)
    {
        Age = age;
    }

    public Person(string fName, string lName, int age, int height) : this(fName, lName, age)
    {
        Height = height;
    }

    public Person() // default contructor
    {
    }

}