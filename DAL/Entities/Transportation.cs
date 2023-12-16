using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Transportation
    {
        public int TransportationId { get; set; }
        public int DriverId { get; set; }
        public int OrderId { get; set; }
        public double Duration { get; set; }
    }

}
