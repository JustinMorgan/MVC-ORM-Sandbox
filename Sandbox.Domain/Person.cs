using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using NHibernate;

namespace Sandbox.Domain
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
