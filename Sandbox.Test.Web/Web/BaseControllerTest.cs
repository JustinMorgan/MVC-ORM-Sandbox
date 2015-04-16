using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox.Test.Web
{
    [TestClass]
    public abstract class BaseControllerTest<TController> : BaseTest
    {
        [TestInitialize]
        public void BaseControllerTestSetup()
        {
            //Arrange.Resolve<IUnitOfWork>();
        }

        protected TController Act()
        {
            return Arrange.Resolve<TController>();
        }
    }
}