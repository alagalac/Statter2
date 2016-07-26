using Core.Models;
using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Api
{
    public class StatisticsController : ApiController
    {
        private readonly Context _context = new Context();

        // GET: api/Statistics
        public IEnumerable<Statistic> Get()
        {
            var stats = _context.Statistics.OrderByDescending(x => x.DateCreated).Take(20);
            return stats;
        }

        // GET: api/Statistics/5
        public IEnumerable<Statistic> Get(string id)
        {
            var stats = _context.Statistics.Where(x => x.Name == id).OrderByDescending(x => x.DateCreated).Take(20);
            return stats;
        }

        // POST: api/Statistics
        public void Post([FromBody]Statistic stat)
        {
            stat.DateCreated = DateTime.Now;
            _context.Statistics.Add(stat);
            _context.SaveChanges();
        }
    }
}