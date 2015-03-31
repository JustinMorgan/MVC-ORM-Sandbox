using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using Sandbox.Domain;
using Sandbox.Web.Constants;
using Sandbox.Web.Models;

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
            //todo: automap
            var models = from p in _personRepository
                         select new PersonModel()
                                {
                                    Id = p.Id,
                                    BirthDate = p.BirthDate,
                                    Name = p.Name
                                };
            return View(models);
        }
    }
}