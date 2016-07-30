using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Controllers;
using Web.Tests;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class StatisticsControllerSpecification
    {
        [TestMethod]
        public void TestIndex()
        {
            var mockRepository = new MockRepository();

            var stat = new Statistic() { Id = 4, DateCreated = DateTime.Now, Name = "Test 1", StatisticValue = 24.56M };
            mockRepository.SaveOrUpdate<Statistic>(stat);

            var controller = new StatisticsController(mockRepository);

            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Statistic>;

            Assert.AreEqual(stat, model.First());
            Assert.IsTrue(model.Count() == 1);
        }

        [TestMethod]
        public void TestShow()
        {
            var mockRepository = new MockRepository();

            var stat = new Statistic() { Id = 4, DateCreated = DateTime.Now, Name = "Test 1", StatisticValue = 24.56M };
            mockRepository.SaveOrUpdate<Statistic>(stat);

            var controller = new StatisticsController(mockRepository);

            var result = controller.Show("Test 1") as ViewResult;
            var model = result.Model as Models.Statistics.Show;

            Assert.AreEqual(stat, model.Statistics.First());
            Assert.IsTrue(model.Statistics.Count() == 1);
        }

        [TestMethod]
        public void TestCreate()
        {
            var mockRepository = new MockRepository();

            var stat = new Statistic() { Id = 4, DateCreated = DateTime.Now, Name = "Test 1", StatisticValue = 24.56M };

            var controller = new StatisticsController(mockRepository);

            var result = controller.Create(stat) as ViewResult;

            var savedItems = mockRepository.Items[typeof(Statistic)];

            Assert.AreEqual(stat, savedItems.First());
            Assert.IsTrue(savedItems.Count() == 1);
        }

        [TestMethod]
        public void TestNew()
        {
            var mockRepository = new MockRepository();

            var controller = new StatisticsController(mockRepository);

            var result = controller.New() as ViewResult;

            var model = result.Model as Statistic;

            Assert.AreEqual(model.Id, 0);
            Assert.AreEqual(model.Name, null);
            Assert.AreEqual(model.StatisticValue, 0M);
        }
    }
}