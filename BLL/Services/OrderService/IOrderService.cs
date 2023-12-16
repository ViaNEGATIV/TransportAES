﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.OrderService
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrders();
    }
}
