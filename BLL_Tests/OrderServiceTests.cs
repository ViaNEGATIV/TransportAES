using BLL.DTO;
using BLL.Services.OrderService;
using CCL;
using CCL.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Tests
{
    public class OrderServiceTests
    {

        [Fact]
        public void Ctor_InputNullableUnitOfWork_ThrowsArgumentNullException()
        {
            IUnitOfWork unitOfWork = null;

            Assert.Throws<ArgumentNullException>(
                () => new OrderService(unitOfWork));
        }

        [Fact]
        public void GetOrders_InputAdministrator_ThrowsMethodAccessException()
        {
            var user = new Administrator(12,"AAA", "BBB");

            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockOrderService = new Mock<OrderService>(mockUnitOfWork.Object);

            // ----

            Assert.Throws<MethodAccessException>(
                () => mockOrderService.Object.GetAllOrders());
        }

        [Fact]
        public void GetOrders_InputClient_ReturnsWellMappedOrdersDTOList()
        {
            var user = new Client(12, "AAA", "BBB");

            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var Orders = new List<Order>(new Order[]
            {
                new Order() { OrderId = 1, RouteId = 5, ExpectedTime = new DateTime(12222222), OrderState = OrderState.Active},
                new Order() { OrderId = 2, RouteId = 2, ExpectedTime = new DateTime(333325555), OrderState = OrderState.Deleted}
            });

            mockUnitOfWork
                .Setup(unit => unit.OrderRepo.GetAll()).Returns(Orders);

            var mockOrderService = new Mock<OrderService>(mockUnitOfWork.Object);

            // ----

            List<OrderDTO> serviceResult = mockOrderService.Object.GetAllOrders().ToList();
            
            // ----

            Assert.Equivalent(serviceResult[0], Orders[0]);
            Assert.Equivalent(serviceResult[1], Orders[1]);
        }

    }
}
