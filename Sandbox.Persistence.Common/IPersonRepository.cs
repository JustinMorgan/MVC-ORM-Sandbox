using Sandbox.Domain.Models;

namespace Sandbox.Persistence.Common
{
    public interface IPersonRepository : IRepository<Person, long>
    {
    }
}
