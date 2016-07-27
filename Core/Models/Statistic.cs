using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Statistic : Entity
    {
        public string Name { get; set; }

        public decimal StatisticValue { get; set; }

        public DateTime DateCreated { get; set; }
    }
}