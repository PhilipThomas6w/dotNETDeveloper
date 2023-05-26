namespace FourPillarsApp;

public class Person
{
    #region FIELDS AND ACCESSORS

    // The historical method of reading data from and writing data to an object employs a private backing field, a
    // getter, and a setter (collectively known as accessor methods).

    // private-backing field
    private string _secret = "password123";

    // A getter is a method that reads/returns data from a private backing field
    public string getSecret(string key)
    {
        if (key == "potatoes") return _secret;
        else return "Invalid key";
    }

    // A setter is a method that writes data to a private backing field
    public void SetSecret(string inputValue)
    {
        _secret = inputValue;
    }

    #endregion

    #region PROPERTIES

    /* The historical read-write framework that relied on writing getter and setter methods was replaced by a more
     * efficient method, using properties. Properties encapsulate a private backing field, a getter and a setter.
     * In C#, a property is a member of a class that provides a flexible mechanism to read, write, or compute the
     * value stored in a private backing field.*/

    /* There are various ways by which the data stored in a private field can be modified:

    1. Initialization at declaration
    2. Constructor initialization
    3. Property setter
    4. Dependency Injection (we will touch on this later in the training course).

    */

    private string _firstName;
    private string _lastName;
    private int _age = 18;  // = 18; == initializer
    public int Age
    {
        get { return _age; }
        set { if (value >= 0) _age = value; }
    }

    public double Height { get; set; } = 180;

    #endregion

    #region CONSTRUCTORS
    // Constructors are a type of method used to instantiate and initialise objects; they do not return data, hence
    // there is no need to declare a return type.

    public Person() { } // default constructor 

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

    #endregion

    #region METHODS

    public virtual string GetFullName()
    {
        return $"{_firstName} {_lastName}";
    }

    public virtual string GetFullName(string title)
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