using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class TransportContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public TransportContext(DbContextOptions options) : base(options)
        {
        }
    }
}
