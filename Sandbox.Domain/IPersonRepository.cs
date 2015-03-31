using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;

namespace Sandbox.Domain
{
    public interface IPersonRepository : IRepository<Person>
    {

    }
}
