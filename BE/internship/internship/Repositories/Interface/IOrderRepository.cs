using internship.Database;
using internship.Model;

namespace internship.Repositories.Interface
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllOrder();
        public Task<List<Order>> GetOrderById(int id);
        Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
        public Task<List<Order>> GetOrderByDateCreated(DateTime date);
        public Task<Order> UpdateOrder(OrderModel order);

        public Task<Order> SoftDeleteOrder(int id);

        public Task<Order> DestroyOrder(int id);


    }
}
