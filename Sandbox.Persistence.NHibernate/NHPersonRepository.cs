using NHibernate;
using Sandbox.Domain.Models;
using Sandbox.Persistence.Common;
using Sandbox.Persistence.NHibernate;

namespace Sandbox.Persistence
{
    public class NHPersonRepository : NHRepository<Person, long>, IPersonRepository
    {
        public NHPersonRepository(ISession session) : base(session)
        {
        }
    }
}
