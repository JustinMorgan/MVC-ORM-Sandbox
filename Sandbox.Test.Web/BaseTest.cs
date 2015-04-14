using AutofacContrib.NSubstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox.Test
{
    [TestClass]
    public abstract class BaseTest
    {
        protected AutoSubstitute ArrangeContext { get; private set; }

        [TestInitialize]
        public void BaseTestSetup()
        {
            ArrangeContext = new AutoSubstitute();
        }

        [TestCleanup]
        protected void TearDown()
        {
            ArrangeContext.Dispose();
        }
    }
}
