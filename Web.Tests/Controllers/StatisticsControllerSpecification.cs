using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class StatisticsControllerSpecification
    {
        [TestMethod]
        public void Testindex()
        {
            var controller = new StatisticsController();

            var result = controller.Index() as ViewResult;
        }
    }
}