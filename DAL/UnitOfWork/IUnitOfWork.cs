using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRouteRepo RouteRepo { get; }
        IOrderRepo OrderRepo { get; }
        void Save();
    }
}
