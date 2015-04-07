using NHibernate;
using Sandbox.Domain.Models;
using Sandbox.Domain.Repositories;

namespace Sandbox.Persistence.NHibernate
{
    public class NHPersonRepository : NHRepository<Person, long>, IPersonRepository
    {
        public NHPersonRepository(ISession session) : base(session)
        {
        }
    }
}
