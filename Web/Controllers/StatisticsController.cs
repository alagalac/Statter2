﻿using Core.Models;
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
        private readonly Context _context = new Context();

        // GET: Statistics
        public ActionResult Index()
        {
            var stats = _context.Statistics.OrderByDescending(x => x.DateCreated).Take(20);

            return View(stats);
        }

        [HttpGet]
        public ActionResult Show(string id)
        {
            var stats = _context.Statistics.Where(x => x.Name == id).OrderByDescending(x => x.DateCreated).Take(20);

            return View(stats);
        }

        [HttpPost]
        public ActionResult Create(Statistic stat)
        {
            stat.DateCreated = DateTime.Now;
            _context.Statistics.Add(stat);
            _context.SaveChanges();

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