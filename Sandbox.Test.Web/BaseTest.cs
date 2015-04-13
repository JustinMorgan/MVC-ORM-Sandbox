using System.Reflection;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Persistence.Common;

namespace Sandbox.Test.Persistence
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IContainer container;

        [TestInitialize]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<IUnitOfWork>()
            container = builder.Build();
        }
    }
}
