using DAL.Entities;
using DAL.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Tests
{
    public class TestReportRepository : BaseRepository<Report>
    {
        public TestReportRepository(DbContext context) : base(context)
        {
        }
    }
}
