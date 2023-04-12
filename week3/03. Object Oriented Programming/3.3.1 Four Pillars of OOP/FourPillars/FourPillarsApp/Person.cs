namespace FourPillarsApp;

public class Person
{
    #region FIELDS

    private string _firstName;
    private string _lastName;

    #region GETTERS AND SETTERS

    // The historical method of reading data from and writing data to an object employs a private backing field, a
    // getter method, and a setter method.

    // private-backing field
    //private string _secret = "password123";

    //// A getter is a method that reads/returns data from a private backing field
    //public string getSecret(string key)
    //{
    //    if (key == "potatoes") return _secret;
    //    else return "Invalid key";
    //}

    //// A setter is a method that writes data to a private backing field
    //public void SetSecret(string inputValue)
    //{
    //    _secret = inputValue;
    //}

    #endregion

    #endregion

    #region PROPERTIES

    /* The historical read-write framework that relied on writing getter and setter methods was replaced by a more
     * efficient method, using properties. In C#, a property is a member of a class that provides a flexible 
     * mechanism to read, write, or compute the value of a private field. Properties are used to encapsulate data
     * and provide a controlled way of accessing and manipulating the data in an object. */

    /* A property is declared busing the get and/or set accessors, which define how the property can be read and
       written to: */
    //public int Age { get; private set; } = 18;


    private int _age = 18;
    public int Age
    {
        get { return _age; }
        set { if (value >= 0) _age = value; }
    }

    public double Height { get; set; } = 180;

    #endregion

    #region METHODS

    #region CONSTRUCTORS
    // Constructors are a type of method used to instantiate and initialise objects; they do not return data, hence
    // there is no need to declare a return type.

    public Person(string fName, string lName)  // This is a constructor
    {
        _firstName = fName;
        _lastName = lName;
    }

    //public Person(string fName, string lName, int age) // This is also a constructor i.e., we have overloaded the Person (constructor) method.
    //{
    //    _firstName = fName;
    //    _lastName = lName;
    //    Age = age;
    //}

    public Person(string fName, string lName, int age) : this(fName, lName)
    {
        Age = age;
    }

    public Person(string fName, string lName, int age, int height) : this(fName, lName, age)
    {
        Height = height;
    }

    public Person() { }

    #endregion

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

    #endregion
}