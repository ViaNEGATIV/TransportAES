
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;

namespace DAL_Tests
{
    public class BaseRepositoryTests
    {

        [Fact]
        public void GetById_InputId_CallsFindMethodForReportDbSetWithId()
        {
            var options = new DbContextOptionsBuilder<TransportContext>().Options;
            var mockTransportContext = new Mock<TransportContext>(options);
            var mockReportDbSet = new Mock<DbSet<Report>>();

            Report expectedReport = new Report()
            {
                ReportId = 1,
                Title = "Звіт за 2021 рік"
            };

            TransportContext transportContext = mockTransportContext.Object;

            mockTransportContext
               .Setup(context => context.Set<Report>()).Returns(mockReportDbSet.Object);

            mockReportDbSet
                .Setup(
                mock => mock.Find(expectedReport.ReportId)
                )
                .Returns(expectedReport);

            TestReportRepository repository = new TestReportRepository(transportContext);

            // -----
            var actionResult = repository.GetById(expectedReport.ReportId);
            // -----

            mockReportDbSet.Verify(
                dbSet => dbSet.Find(expectedReport.ReportId), Times.Once());
            Assert.Equal(expectedReport, actionResult);
        }

        [Fact]
        public void Create_InputReportInstance_CallsAddMethodForReportDbSetWithWellInstance()
        {
            var options = new DbContextOptionsBuilder<TransportContext>().Options;
            var mockTransportContext = new Mock<TransportContext>(options);
            var mockReportDbSet = new Mock<DbSet<Report>>();

            TransportContext transportContext = mockTransportContext.Object;

            mockTransportContext
               .Setup(
                context => context.Set<Report>()
                )
               .Returns(mockReportDbSet.Object);

            TestReportRepository repository = new TestReportRepository(transportContext);
            Report expectedReport = new Mock<Report>().Object;

            // -----
            repository.Create(expectedReport);
            // -----

            mockReportDbSet.Verify(
                dbSet => dbSet.Add(expectedReport), Times.Once());
        }

        [Fact]
        public void Update_InputReportInstance_CallsUpdateMethodForDbSetWithWellInstance()
        {
            var options = new DbContextOptionsBuilder<TransportContext>().Options;
            var mockTransportContext = new Mock<TransportContext>(options);
            var mockReportDbSet = new Mock<DbSet<Report>>();

            Report expectedReport = new Report()
            {
                ReportId = 2,
                Title = "Звіт за 2023 рік"
            };

            TransportContext transportContext = mockTransportContext.Object;

            mockTransportContext
               .Setup(
                context => context.Set<Report>()
                )
               .Returns(mockReportDbSet.Object);

            TestReportRepository repository = new TestReportRepository(transportContext);

            // -----
            repository.Update(expectedReport);
            // -----

            mockTransportContext.Verify(
                context => context.Update(expectedReport), Times.Once
                );
        }

        [Fact]
        public void Delete_InputId_CallsFindMethodForDbSetWithId()
        {
            var options = new DbContextOptionsBuilder<TransportContext>().Options;
            var mockTransportContext = new Mock<TransportContext>(options);
            var mockReportDbSet = new Mock<DbSet<Report>>();

            Report expectedReport = new Report()
            {
                ReportId = 3,
                Title = "Звіт за 2021 рік",
                TotalCost = 100000,
            };

            TransportContext transportContext = mockTransportContext.Object;

            mockTransportContext
               .Setup(
                context => context.Set<Report>()
                )
               .Returns(mockReportDbSet.Object);

            mockReportDbSet
                .Setup(mock => mock.Find(expectedReport.ReportId)).Returns(expectedReport);

            TestReportRepository repository = new TestReportRepository(transportContext);

            // -----
            repository.Delete(expectedReport.ReportId);
            // -----

            mockReportDbSet.Verify(
                repo => repo.Find(expectedReport.ReportId), Times.Once());
            mockReportDbSet.Verify(
                dbSet => dbSet.Remove(expectedReport), Times.Once());
        }
    }
}
