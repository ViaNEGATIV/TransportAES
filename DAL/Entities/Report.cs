using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Title { get; set; }
        public List<int> transportationIds { get; set; }
        public double TotalCost { get; set; }
    }
}
