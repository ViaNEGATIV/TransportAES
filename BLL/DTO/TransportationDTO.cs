﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TransportationDTO
    {
        public int TransportationId { get; set; }
        public int DriverId { get; set; }
        public int OrderId { get; set; }
        public double Duration { get; set; }
    }
}
