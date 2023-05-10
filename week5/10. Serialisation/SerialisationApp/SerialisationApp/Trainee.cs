﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SerializationApp;

public class Trainee
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int? SpartaNo { get; init; }

    [JsonIgnore]
    public string FullName => $" {FirstName} {LastName}";
    
    public override string ToString()
    {
        return $"{base.ToString()} {SpartaNo} - {FullName}";
    }
}
