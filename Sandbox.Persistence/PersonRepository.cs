using NHibernate;
using Sandbox.Domain;

namespace Sandbox.Persistence
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ISession session) : base(session)
        {
        }
    }
}
