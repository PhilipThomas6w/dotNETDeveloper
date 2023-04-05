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

    public int Age { get; set; }

    public Person(string fName, string lName) // This is a *constructor*. Note, 1) Same name as class 2) No return type.
    {
        _firstName = fName;                     // This is a field - note the naming convention.
        _lastName = lName;
    }

    public string GetFullName()
    {
        return $"{_firstName} + {_lastName}";
    }


    


}