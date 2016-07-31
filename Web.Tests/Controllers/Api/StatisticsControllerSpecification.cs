using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Web.Controllers.Api;

namespace Web.Tests.Controllers.Api
{
    [TestClass]
    public class StatisticsControllerSpecification
    {
        [TestMethod]
        public void TestGet()
        {
            var mockRepository = new MockRepository();

            var stat = new Statistic() { Id = 4, DateCreated = DateTime.Now, Name = "Test 1", StatisticValue = 24.56M };
            mockRepository.SaveOrUpdate<Statistic>(stat);

            var controller = new StatisticsController(mockRepository);

            var result = controller.Get() as OkNegotiatedContentResult<IQueryable<Statistic>>;
            var items = result.Content;

            Assert.AreEqual(stat, items.First());
            Assert.IsTrue(items.Count() == 1);
        }

        [TestMethod]
        public void TestGetSpecific()
        {
            var mockRepository = new MockRepository();

            var stat1 = new Statistic() { Id = 4, DateCreated = DateTime.Now, Name = "Test 1", StatisticValue = 24.56M };
            mockRepository.SaveOrUpdate<Statistic>(stat1);

            var stat2 = new Statistic() { Id = 5, DateCreated = DateTime.Now, Name = "Test 2", StatisticValue = 20M };
            mockRepository.SaveOrUpdate<Statistic>(stat2);

            var controller = new StatisticsController(mockRepository);

            var result = controller.Get("Test 1") as OkNegotiatedContentResult<IQueryable<Statistic>>;
            var items = result.Content;

            Assert.AreEqual(stat1, items.First());
            Assert.IsTrue(items.Count() == 1);
        }

        [TestMethod]
        public void TestPost()
        {
            var mockRepository = new MockRepository();

            var stat1 = new Statistic() { Id = 4, DateCreated = DateTime.Now, Name = "Test 1", StatisticValue = 24.56M };

            var controller = new StatisticsController(mockRepository);

            controller.Post(stat1);

            var savedItems = mockRepository.Items[typeof(Statistic)];

            Assert.AreEqual(stat1, savedItems.First());
            Assert.IsTrue(savedItems.Count() == 1);
        }
    }
}