using System;
using System.Linq;
using System.Web.Mvc;
using Sandbox.Domain.Models;
using Sandbox.Persistence.Common;
using Sandbox.Web.Models;
using Sandbox.Web.Models.Mapping;
using Sandbox.Web.Utils;

namespace Sandbox.Web.Controllers
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
            var models = _personRepository.Query()
                                          .Select(person => person.ToModel());
            return View(models);
        }

        [HttpGet]
        public ActionResult Add()
        {
            //test data
            var rand = new Random();
            var age = rand.Next(50);
            var gender = age % 2 == 1
                ? Person.GenderType.Male
                : Person.GenderType.Female;

            var model = new PersonModel()
            {
                Name = "test " + rand.Next(200),
                BirthDate = DateTime.Today.AddYears(-age),
                Gender = gender
            };

            return View("Add", model);
        }

        [HttpGet]
        [UnitOfWork]
        public ActionResult Update(long id)
        {
            var person = _personRepository.Get(id);
            if (person != null)
            {
                var model = person.ToModel();
                return View("Update", model);
            }
            //todo: error handling/validation
            throw new NotImplementedException();
        }

        [HttpPost]
        [UnitOfWork]
        public ActionResult Add(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                var person = model.ToEntity();
                if (person.Id == default(long))
                {
                    _personRepository.Add(person);
                    return RedirectToAction("Index");
                }
            }
            //todo: error handling/validation
            throw new NotImplementedException();
        }

        [HttpPost]
        [UnitOfWork]
        public ActionResult Update(long id, PersonModel model)
        {
            if (ModelState.IsValid)
            {
                //todo: set repo to decide equivalence by ID 
                var person = _personRepository.Get(id);
                if (person != null)
                {
                    person.Name = model.Name;
                    person.ChangeBirthdate(model.BirthDate);
                    person.Gender = model.Gender;
                    _personRepository.Update(person); //todo: test without this line
                    return RedirectToAction("Index");
                }
            }
            //todo: error handling/validation
            throw new NotImplementedException();
        }

        [HttpDelete]
        [UnitOfWork]
        public JsonResult Delete(long id)
        {
            var person = _personRepository.Get(id);
            if (person != null)
            {
                _personRepository.Remove(person);
                return Json(
                    new {id} 
                    //, JsonRequestBehavior.AllowGet //debug only
                );
            }
            //todo: error handling/validation
            throw new NotImplementedException();
        }
    }
}
