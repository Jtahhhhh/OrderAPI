using internship.Controllers.SubmitModels;
using Microsoft.AspNetCore.Mvc;

namespace internship.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository UsersRepo { get; }
        IItemRepository ItemRepo { get; }
        IOrderDetailRepository OrderDetailRepo { get; }
        IOrderRepository OrderRepository { get; }


        Task<IActionResult> SearchOrder(SearchOrderForm Order);
        Task<IActionResult> EditOrder(EditOrderForm Order);
        Task<IActionResult> AddOrder();
        Task SaveChange();
    }
}
