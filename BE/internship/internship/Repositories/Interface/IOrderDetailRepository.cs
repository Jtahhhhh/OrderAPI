using internship.Controllers.SubmitModels;
using internship.Database;
using internship.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace internship.Repositories.Interface
{
    public interface IOrderDetailRepository
    {
        public Task<List<Order_detail>> GetAllOrderDetailInOrder(int OrderId);
        Task<IEnumerable<Order_detail>> GetOrderDetailsByItemId(int itemId);

        public Task<IActionResult> AddOrderDetail(AddOrderDetailForm orderDetail);
    }
}
