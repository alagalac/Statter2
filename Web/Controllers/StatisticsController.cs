using Core.Models;
using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IRepository _repository = new EntityFrameworkRepository(new Context());

        // GET: Statistics
        public ActionResult Index()
        {
            var stats = _repository.GetAll<Statistic>().OrderByDescending(x => x.DateCreated).Take(20);

            return View(stats);
        }

        [HttpGet]
        public ActionResult Show(string id)
        {
            var model = new Models.Statistics.Show();
            model.Name = id;
            model.Statistics = _repository.GetAll<Statistic>().Where(x => x.Name == id).OrderByDescending(x => x.DateCreated).Take(20);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Statistic stat)
        {
            stat.DateCreated = DateTime.Now;

            _repository.SaveOrUpdate<Statistic>(stat);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var stat = new Statistic();

            return View(stat);
        }
    }
}