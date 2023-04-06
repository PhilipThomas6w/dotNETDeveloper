using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FourPillarsApp;

public class Person
{
    private string _firstName;
    private string _lastName;

    public int Age { get; set; }                // This is a property (note the {get; set; } feature)

    public Person(string fName, string lName)   // This is a *constructor*. Note, 1) Same name as class 2) No return type.
    {
        _firstName = fName;                     // This is a field - note the _namingConvention
        _lastName = lName;
    }

    public Person(string fName, string lName, int age) : this(fName, lName)
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