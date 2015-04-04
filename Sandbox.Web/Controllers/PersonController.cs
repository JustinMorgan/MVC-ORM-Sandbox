using System;
using System.Linq;
using System.Web.Mvc;
using Sandbox.Domain.Models;
using Sandbox.Persistence.Common;
using Sandbox.Web2.Models;
using Sandbox.Web2.Models.Mapping;

namespace Sandbox.Web2.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [UnitOfWork]
        public ActionResult Index()
        {
            var models = _personRepository.Select(person => person.ToModel());
            return View(models);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var rand = new Random();
            var age = rand.Next(50);
            var gender = age % 2 == 1
                ? Person.GenderType.Male
                : Person.GenderType.Female;

            var model = new PersonModel()
            {
                Name = "test " + rand.Next(200),
                BirthDate = DateTime.Today.AddYears(-age)
            };

            return View("Edit", model);
        }

        [HttpGet]
        [UnitOfWork]
        public ActionResult Update(long id)
        {
            //todo: error handling
            var person = _personRepository.Get(id);
            var model = person.ToModel();
            return View("Edit", model);
        }

        [HttpPost]
        [UnitOfWork]
        public ActionResult Save(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                var person = model.ToEntity();
                _personRepository.AddOrUpdate(person);
            }
            else
            {
                //todo: error handling
                throw new NotImplementedException();
            }
                
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [UnitOfWork]
        public ActionResult Delete(long id)
        {
            //todo: error handling
            var person = _personRepository.Get(id);
            _personRepository.Remove(person);
            return RedirectToAction("Index");
        }
    }
}
