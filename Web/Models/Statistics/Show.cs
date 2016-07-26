using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Statistics
{
    public class Show
    {
        public string Name { get; set; }

        public IEnumerable<Statistic> Statistics { get; set; }
    }
}