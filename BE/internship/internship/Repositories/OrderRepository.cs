using AutoMapper;
using internship.Database;
using internship.Model;
using internship.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace internship.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDBContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(FoodDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        public Task<Order> DestroyOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrderByDateCreated(DateTime date)
        {
            try
            {
                var item = await _context.Order.Where(i => i.Date_create == date).ToListAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve Order by Date", ex);
            }
        }


        public async Task<List<Order>> GetOrderById(int id)
        {
            try
            {
                var item = await _context.Order.Where(i => i.Order_Id == id).ToListAsync();
                return _mapper.Map<List<Order>>(item);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve Order by Date", ex);
            }
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            return await _context.Order.Where(o => o.Id == userId).ToListAsync();
        }
        public Task<Order> SoftDeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
