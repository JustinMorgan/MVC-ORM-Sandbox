using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Test.TestData;

namespace Sandbox.Test.Domain
{
    [TestClass]
    public class PersonEntityTests : BaseTest
    {
        [TestMethod]
        public void CanChangeBirthdate()
        {
            var oldDate = DateTime.Now;
            var newDate = oldDate.AddDays(-10);
            var person = new FakePerson(birthDate: oldDate);

            Assert.AreNotEqual(oldDate, newDate);
            Assert.AreEqual(person.BirthDate, oldDate);

            person.ChangeBirthdate(newDate);

            Assert.AreEqual(person.BirthDate, newDate);
        }
    }
}
