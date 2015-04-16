using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Domain.Models;
using Sandbox.Test.TestData;
using Sandbox.Web.Models;
using Sandbox.Web.Models.Mapping;

namespace Sandbox.Test.Web
{
    [TestClass]
    public class ModelMappingTests
    {
        [TestMethod]
        public void CanMapFromPersonToPersonModel()
        {
            //arrange
            var person = Fake.Person();

            //act
            var model = person.ToModel();

            //assert
            Assert.AreEqual(model.Id, person.Id);
            Assert.AreEqual(model.Name, person.Name);
            Assert.AreEqual(model.BirthDate, person.BirthDate);
            Assert.AreEqual(model.Gender, person.Gender);
        }

        [TestMethod]
        public void CanMapFromPersonModelToPerson()
        {
            //arrange
            var model = new PersonModel()
            {
                Id = 111,
                Name = "test",
                BirthDate = DateTime.Now,
                Gender = Person.GenderType.Male,
            };

            //act
            var person = model.ToEntity();

            //assert
            Assert.AreEqual(model.Id, person.Id);
            Assert.AreEqual(model.Name, person.Name);
            Assert.AreEqual(model.BirthDate, person.BirthDate);
            Assert.AreEqual(model.Gender, person.Gender);
        }
    }
}