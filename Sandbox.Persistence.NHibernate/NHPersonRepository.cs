using System;
using System.Linq;
using NHibernate.Linq;
using Sandbox.Domain.Models;
using Sandbox.Persistence.Common;
using Sandbox.Persistence.NHibernate;

namespace Sandbox.Persistence
{
    public class NHPersonRepository : NHRepository<Person, Guid>, IPersonRepository
    {
        public NHPersonRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable<Person> QueryByGender(Person.GenderType gender)
        {
            return Query(p => p.Gender == gender);
        }
    }
}
