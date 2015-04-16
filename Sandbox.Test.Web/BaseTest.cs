using AutofacContrib.NSubstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox.Test
{
    [TestClass]
    public abstract class BaseTest
    {
        protected AutoSubstitute Arrange { get; private set; }

        protected T AssertThat<T>()
        {
            return Arrange.Resolve<T>();
        }

        [TestInitialize]
        public void BaseTestSetup()
        {
            Arrange = new AutoSubstitute();
        }

        [TestCleanup]
        public void TearDown()
        {
            Arrange.Dispose();
        }
    }
}
