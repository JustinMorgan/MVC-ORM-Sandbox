using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Sandbox.Domain.Models;
using Sandbox.Persistence.Common;
using Sandbox.Test.TestData;
using Sandbox.Web.Controllers;
using Sandbox.Web.Models;
using Sandbox.Web.Models.Mapping;

namespace Sandbox.Test.Web
{
    [TestClass]
    public class PersonControllerTests : BaseControllerTest<PersonController>
    {
        [TestMethod]
        public void CanShowPersonList()
        {
            //arrange
            var people = FakePerson.PersonList().AsQueryable();
            Arrange.Resolve<IPersonRepository>().Query().Returns(people);

            //act
            var result = Act().Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            //Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void PersonListMapsCorrectly()
        {
            //arrange
            var people = FakePerson.PersonList().AsQueryable();
            Arrange.Resolve<IPersonRepository>().Query().Returns(people);

            //act
            var result = Act().Index() as ViewResult;
            var models = result.Model as IQueryable<PersonModel>;

            //assert
            Assert.IsNotNull(models);
            Assert.AreEqual(models.Count(), people.Count());
        }

        [TestMethod]
        public void CanAddPerson()
        {
            //arrange
            var model = new FakePerson(id: default(Guid)).ToModel();
            var repo = Arrange.Resolve<IPersonRepository>();

            //act
            var result = Act().Add(model) as RedirectToRouteResult;

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteValues["action"].ToString(), "Index");
            AssertThat<IPersonRepository>().Received(1).Add(Arg.Any<Person>());
        }
    }
}
