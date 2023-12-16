using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int RouteId { get; set; }
        public DateTime ExpectedTime { get; set; }
        public OrderState OrderState { get; set; }
    }
}
