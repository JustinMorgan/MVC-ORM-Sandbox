using System;
using System.Collections.Generic;
using PersonEntity = Sandbox.Domain.Models.Person;

namespace Sandbox.Test.TestData
{
    public class FakePerson : PersonEntity
    {
        public FakePerson(Guid? id = null, string name = "fake", GenderType gender = GenderType.Female, DateTime? birthDate = null)
        {
            this.Id = id ?? Guid.NewGuid();
            this.Name = name;
            this.BirthDate = birthDate ?? DateTime.Now;
            this.Gender = gender;
        }

        public static List<FakePerson> PersonList()
        {
            return new List<FakePerson>
            {
                new FakePerson(Guid.NewGuid(), "foo"),
                new FakePerson(Guid.NewGuid(), "bar"),
                new FakePerson(Guid.NewGuid(), "baz")
            };
        }
    }
}