using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int RouteId { get; set; }
        public DateTime ExpectedTime { get; set; }
        public OrderState OrderState{ get; set; }
    }

    public enum OrderState
    {
        Proccesing, 
        NotVerified,
        Verified,
        Active,
        Deleted
    }
}
