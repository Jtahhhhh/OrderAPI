using AutoMapper;
using internship.Controllers.SubmitModels;
using internship.Database;
using internship.Model;
using internship.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace internship.Repositories
{
    public class UnitOfWord : IUnitOfWork
    {
        private readonly FoodDBContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;

        public UnitOfWord(
            FoodDBContext foodDBContext,
            IMapper mapper,
            IUserRepository userRepository,
            IItemRepository itemRepository,
            IOrderDetailRepository orderDetailRepository,
            IOrderRepository orderRepository)
        {
            _context = foodDBContext;
            _mapper = mapper;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
        }

        public IUserRepository UsersRepo => _userRepository;

        public IItemRepository ItemRepo => _itemRepository;

        public IOrderDetailRepository OrderDetailRepo => _orderDetailRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public Task<IActionResult> AddOrder(AddOrderDetailForm form)
        {
            if (form == null) {
                return new BadRequestObjectResult("Invalid search criteria.");
            }
            else
            {
                return new OkObjectResult( _orderDetailRepository.AddOrderDetail(form));
            }
            
        }

        public Task<IActionResult> EditOrder(EditOrderForm order)
        {
            throw new NotImplementedException();
        }

        public Task SaveChange()
        {
            return _context.SavedChanges();
        }

        public async Task<IActionResult> SearchOrder(SearchOrderForm order)
        {
            try
            {
                if (order.Date == null && string.IsNullOrEmpty(order.CustomerName)  && order.ItemId == null)
                {
                    return new BadRequestObjectResult("Invalid search criteria.");
                }

                var orders = new List<Order>();
                var orderDetailsList = new List<Order_detail>();
                var usersList = new List<User>();
                var itemsList = new List<Item>();

                // Search by date
                if (order.Date != null)
                {
                    orders = await _orderRepository.GetOrderByDateCreated(order.Date);
                }

                // Search by customer name
                if (!string.IsNullOrEmpty(order.CustomerName))
                {
                    var users = await _userRepository.GetUsersByName(order.CustomerName);
                    foreach (var user in users)
                    {
                        var userOrders = await _orderRepository.GetOrdersByUserId(user.Id);
                        orders.AddRange(userOrders);
                    }
                }

                // Search by item ID
                if (order.ItemId != null)
                {
                    var orderDetails = await _orderDetailRepository.GetOrderDetailsByItemId(order.ItemId);
                    foreach (var detail in orderDetails)
                    {
                        var order1 = await _orderRepository.GetOrderById(detail.Order_Id);
                        if (order1 != null)
                        {
                            orders.AddRange(order1);
                        }
                    }
                }

                // Avoid duplicate orders
                orders = orders.Distinct().ToList();

                foreach (var ord in orders)
                {
                    // Fetching order details
                    var orderDetails = await _orderDetailRepository.GetAllOrderDetailInOrder(ord.Id);
                    orderDetailsList.AddRange(orderDetails);

                    // Fetching user details
                    var user = await _userRepository.GetUserById(ord.Id);
                    if (user != null)
                    {
                        usersList.Add(_mapper.Map<User>(user));
                    }

                    // Fetching item details
                    foreach (var orderDetail in orderDetails)
                    {
                        var item = await _itemRepository.GetItemByid(orderDetail.Item_Id.ToString());
                        if (item != null)
                        {
                            itemsList.Add(_mapper.Map<Item>(item));
                        }
                    }
                }

                return new OkObjectResult(new { Orders = orders, OrderDetails = orderDetailsList, Users = usersList, Items = itemsList });
            }
            catch (Exception ex)
            {
                // Logging the error (assuming a logger is available)
                // logger.LogError(ex, "An error occurred while searching for orders.");
                return new StatusCodeResult(500);
            }
        }

    }
}
