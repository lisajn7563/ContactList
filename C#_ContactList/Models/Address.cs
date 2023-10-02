﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ContactList.Models;

public class Address
{
    public string? StreetName { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public string? FullAddress => $"{StreetName}, {ZipCode}, {City}, {Country}";


}
