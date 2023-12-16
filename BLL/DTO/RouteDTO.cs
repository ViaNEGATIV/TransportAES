using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RouteDTO
    {
        public int RouteId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public TimeSpan AvgDuration { get; set; }
    }
}
