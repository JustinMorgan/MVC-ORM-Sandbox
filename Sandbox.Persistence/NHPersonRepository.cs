using NHibernate;
using Sandbox.Domain;

namespace Sandbox.Persistence.NHibernate
{
    public class NHPersonRepository : NHRepository<Person>, IPersonRepository
    {
        public NHPersonRepository(ISession session) : base(session)
        {
        }
    }
}
