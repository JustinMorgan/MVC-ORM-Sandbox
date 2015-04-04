﻿using System;
using Sandbox.Domain.Models;

namespace Sandbox.Web2.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Person.GenderType Gender { get; set; }
    }
}