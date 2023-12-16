using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private TransportContext context;
        public IRouteRepo RouteRepo { get;  }
        public IOrderRepo OrderRepo { get; } 

        private bool _disposed = false;

        public EFUnitOfWork(DbContextOptions options, IRouteRepo routeRepo, IOrderRepo orderRepo)
        {
            context = new TransportContext(options);
            RouteRepo = routeRepo;
            OrderRepo = orderRepo;
        }


        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
