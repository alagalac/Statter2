using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Web.Controllers;
using Web.Tests;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class StatisticsControllerSpecification
    {
        [TestMethod]
        public void Testindex()
        {
            var mockRepository = new MockRepository();

            var stat = new Statistic() { Id = 4, DateCreated = DateTime.Now, Name = "Test 1", StatisticValue = 24.56M };
            mockRepository.SaveOrUpdate<Statistic>(stat);

            var controller = new StatisticsController(mockRepository);

            var result = controller.Index() as ViewResult;

            //Assert.Equals(stat, result.Model)
        }
    }
}