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
        private readonly IRepository _repository; // = new EntityFrameworkRepository(new Context());

        public StatisticsController(IRepository repo)
        {
            _repository = repo;
        }

        // GET: api/Statistics
        public IHttpActionResult Get()
        {
            var stats = _repository.GetAll<Statistic>().OrderByDescending(x => x.DateCreated).Take(20);
            return Ok(stats);
        }

        // GET: api/Statistics/5
        public IHttpActionResult Get(string id)
        {
            var stats = _repository.GetAll<Statistic>().Where(x => x.Name == id).OrderByDescending(x => x.DateCreated).Take(20);
            return Ok(stats);
        }

        // POST: api/Statistics
        public IHttpActionResult Post([FromBody]Statistic stat)
        {
            stat.DateCreated = DateTime.Now;

            _repository.SaveOrUpdate<Statistic>(stat);

            return Ok();
        }
    }
}