using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FourPillarsApp;

public class Person
{
    private string _firstName;                  // This is a field
    private string _lastName;                   // This is also a field

    #region Manual example of Getting data from and storing data in (i.e., Setting) a field
    private string _secret = "password123";     // This is a private backing field

    public string GetSecret(string key)         // This is a getter, a method that returns data from a private backing field      
    {
        if (key == "potatoes") return _secret;
        else return "Invalid Key";
    }


    private void SetSecret(string inputValue)    // This is a setter, a method that puts some new data into a private backign field.
    {
        _secret = inputValue;
    }
    #endregion

    #region An example of Getting data from and storing data in a property
    /*public int Age { get; set; } = 18;*/       // This is a property (note the {get; set; } feature)

    private int _age = 18;
    public int Age                               // If we want to customise get; and set;, we can treat them like method calls.
    {
        get
        {
            return _age;
        }
        set
        {
            if (value >= 0) _age = value;        // value stands for the passed in value.                    
        }
    }

    //public int Age                             // is the same as above, just written in a different style
    //{   
    //    get { return _age;}
    //    set { if (value >= 0) _age = value; }
    //}

    public double Height { get; set; }          // type <prop> and select top option to fill out the property instruction automatically    

    #endregion

    public Person(string fName, string lName)   // This is a *constructor*. Note, 1) Same name as class 2) No return type.
    {
        _firstName = fName;                     // This is a field - note the _namingConvention
        _lastName = lName;
    }

    public Person(string fName, string lName, int age) : this(fName, lName) // this() refers to the constructor that takes two strings as arguments.
    {
        _firstName = fName;                     
        _lastName = lName;
        Age = age;
    }


    public string GetFullName()
    {
        return $"{_firstName} {_lastName}";
    }

    public string GetFullName(string title)
    {
        //return $"{title} {_firstName} {_lastName}";
        return $"{title} {GetFullName()}";
    }




}