using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sandbox.Domain;
using Sandbox.Web2.Models;

namespace Sandbox.Web2.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ActionResult Index()
        {
            var models = _personRepository.Select(
                person => new PersonModel()
                          {
                              Id = person.Id,
                              BirthDate = person.BirthDate,
                              Name = person.Name
                          });
            return View(models);
        }

    }
}
