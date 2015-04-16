using System;
using System.Collections.Generic;
using NSubstitute;
using PersonEntity = Sandbox.Domain.Models.Person;

namespace Sandbox.Test.TestData
{
    /// <summary>
    /// Generates fake data objects for tests
    /// </summary>
    public static partial class Fake
    {
        public static PersonEntity Person(long id = 123, string name = "test", PersonEntity.GenderType gender = PersonEntity.GenderType.Female, DateTime? birthDate = null)
        {
            var person = Substitute.For<PersonEntity>();
            person.Id.Returns(id);
            person.Name.Returns(name);
            person.BirthDate.Returns(birthDate ?? DateTime.Now);
            person.Gender.Returns(gender);

            return person;
        }

        public static List<PersonEntity> PersonList()
        {
            return new List<PersonEntity>
            {
                Person(111, "foo"),
                Person(222, "bar"),
                Person(333, "baz")
            };
        }
    }
}