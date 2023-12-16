using DAL.EF;
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementations
{
    public class RouteRepo : BaseRepository<Route>, IRouteRepo
    {
        public RouteRepo(TransportContext context) : base(context)
        {
        }
    }
}
