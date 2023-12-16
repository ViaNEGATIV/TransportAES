using AutoMapper;
using BLL.DTO;
using CCL;
using CCL.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var user = SecurityContext.GetUser();

            if (user.GetType() != typeof(Client) && user.GetType() != typeof(Operator))
            {
                throw new MethodAccessException();
            }

            var ordersResult = _unitOfWork.OrderRepo.GetAll();

            var mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<Order, OrderDTO>()
                .ReverseMap())
                .CreateMapper();

            var ordersDTOResult = mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(ordersResult);

            return ordersDTOResult;
        }
    }
}
