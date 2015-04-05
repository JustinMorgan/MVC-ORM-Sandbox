using NHibernate;
using Sandbox.Domain.Models;
using Sandbox.Domain.Repositories;
using Sandbox.Persistence.Common;

namespace Sandbox.Persistence.NHibernate
{
    public class NHPersonRepository : NHRepository<Person>, IPersonRepository
    {
        public NHPersonRepository(ISession session) : base(session)
        {
        }
    }
}
