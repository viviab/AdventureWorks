using System;
using System.Net.Http;
using System.Web.Http;
using AdventureWorks.UI.Api;
using NUnit.Framework;
using System.Web;
using System.Collections.Specialized;
using System.Reflection;

namespace AdventureWorks.IntegrationTests
{
    [TestFixture]
    public class ControllerTestBase<T> where T : ApiController
    {
        protected static T Controller;

        [SetUp]
        public void SetupControllerBase()
        {
            NinjectWebCommon.Start();
            MappingConfiguration.Start();

            var config = GlobalConfiguration.Configuration.DependencyResolver;

            Controller = (T)Convert.ChangeType(config.GetService(typeof(T)), typeof(T));

            if (Controller == null)
                return;

            Controller.Request = new HttpRequestMessage();
            Controller.Request.SetConfiguration(new HttpConfiguration());

        }

        [Test]
        public void Test_VerifyController()
        {
            Assert.IsNotNull(Controller, $"Controller is not corrected injected {typeof(T)}");
        }

        [TearDown]
        public void CleanupControllerBase()
        {
            NinjectWebCommon.Stop();
            MappingConfiguration.Stop();
        }

    }
}
