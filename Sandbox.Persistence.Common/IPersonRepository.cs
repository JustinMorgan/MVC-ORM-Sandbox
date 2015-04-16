using System;
using System.Linq;
using Sandbox.Domain.Models;

namespace Sandbox.Persistence.Common
{
    public interface IPersonRepository : IRepository<Person, Guid>
    {
        IQueryable<Person> QueryByGender(Person.GenderType gender);
    }
}
