using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Route
    {
        public int RouteId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public TimeSpan AvgDuration { get; set; }
    }
}
