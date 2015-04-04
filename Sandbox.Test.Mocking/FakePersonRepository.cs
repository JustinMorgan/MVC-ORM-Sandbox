using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sandbox.Domain.Models;
using Sandbox.Persistence.Common;

namespace Sandbox.Test.Mocking
{
    public class FakePersonRepository : IPersonRepository
    {
        private readonly List<Person> _list;

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

        public IQueryable<Person> Query()
        {
            throw new NotImplementedException();
        }

        public void Add(Person entity)
        {
            _list.Add(entity);
        }

        public void Update(Person entity)
        {
            _list.RemoveAll(p => p.Id == entity.Id);
            _list.Add(entity);
        }

        public void AddOrUpdate(Person entity)
        {
            throw new NotImplementedException();
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
