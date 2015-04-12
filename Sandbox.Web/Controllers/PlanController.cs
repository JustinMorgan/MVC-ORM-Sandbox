using System;
using System.Linq;
using System.Web.Mvc;
using Sandbox.Domain.Models;
using Sandbox.Persistence.Common;
using Sandbox.Web.Models;

namespace Sandbox.Web.Controllers
{
    public class PlanController : Controller
    {
        //private readonly IRepository<Plan, Guid> _repository;

        //public PlanController(IRepository<Plan, Guid> repository)
        //{
        //    _repository = repository;
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //    var models = _repository.Query().Select(p => p.ToModel());
        //    return View(models);
        //}
        public ActionResult Create()
        {
            var model = new PlanModel();
            return View(model);
        }
    }
}
