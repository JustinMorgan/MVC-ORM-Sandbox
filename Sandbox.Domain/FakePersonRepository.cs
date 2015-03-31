using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sandbox.Domain
{
    public class FakePersonRepository : IPersonRepository
    {
        protected readonly List<Person> _list;

        public FakePersonRepository()
        {
            _list = new List<Person>()
                    {
                        new Person()
                        {
                            BirthDate = DateTime.Now.AddYears(-10),
                            Id = new Random().Next(),
                            Name = "foo"
                        },
                        new Person()
                        {
                            BirthDate = DateTime.Now.AddYears(-20),
                            Id = new Random().Next(),
                            Name = "bar"
                        },
                        new Person()
                        {
                            BirthDate = DateTime.Now.AddYears(-30),
                            Id = new Random().Next(),
                            Name = "baz"
                        }
                    };
        }

        public Person Get(long id)
        {
            return _list.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Person entity)
        {
            _list.Add(entity);
        }

        public void Remove(Person entity)
        {
            _list.Remove(entity);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { return _list.AsQueryable().Expression; }
        }

        public Type ElementType
        {
            get { return typeof(Person); }
        }

        public IQueryProvider Provider
        {
            get { return _list.AsQueryable().Provider; }
        }
    }
}
