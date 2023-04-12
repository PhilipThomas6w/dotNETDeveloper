namespace ObjectEqualityAndComparisonApp;

public class Person : IEquatable<Person?>
{
    // Fields
    
    private string _firstName = "";
    private string _lastName = "";

    // Properties

    public int Age { get; set; }

    // Constructors

    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Person);
    }

    public bool Equals(Person? other)
    {
        return other is not null &&
               _firstName == other._firstName &&
               _lastName == other._lastName &&
               Age == other.Age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_firstName, _lastName, Age);
    }

    //public int CompareTo(Person? other)
    //{
    //    // if null return 1
    //    if (other is null) return 1;

    //    // if lastname is equal, check first name
    //    if (other._lastName == _lastName)
    //    {
    //        // if firstname is equal, check age
    //        if (other._firstName == _firstName)
    //        {
    //            // if age is equal, return 0
    //            if (other.Age == Age) return 0;
    //            else return Age.CompareTo(other.Age);
    //        }
    //        else return _firstName.CompareTo(other._firstName);
    //    }
    //    else return _lastName.CompareTo(other._lastName);
    //}
    public int CompareTo(Person? other)
    {
        // if null return 1
        if (other is null) return 1;

        // if lastname is equal, check first name
        if (other._lastName == _lastName)
        {
            // if firstname is equal, check age
            if (other._firstName == _firstName)
            {
                // if age is equal, return 0
                if (other.Age == Age) return 0;
                else return Age.CompareTo(other.Age);
            }
            else return _firstName.CompareTo(other._firstName);
        }
        else return _lastName.CompareTo(other._lastName);
    }


    public string GetFullName()
    {
        return $"{_firstName} {_lastName}";
    }

    public static bool operator ==(Person left, Person right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

    // Methods




}