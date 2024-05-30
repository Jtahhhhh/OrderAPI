using AutoMapper;
using internship.Controllers.SubmitModels;
using internship.Database;
using internship.Model;
using internship.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace internship.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly FoodDBContext _context;
        private readonly IMapper _mapper;

        public OrderDetailRepository(FoodDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> AddOrderDetail(AddOrderDetailForm orderDetail)
        {
            try
            {
                // Find existing order details with the same OrderID and ItemID
                var existingOrderDetails = _context.Order_Details
                                                   .Where(o => o.Order_Id == orderDetail.OrderID && o.Item_Id == orderDetail.ItemID)
                                                   .ToList();

                if (existingOrderDetails.Any())
                {
                    // If they exist, increment the quantity
                    foreach (var order in existingOrderDetails)
                    {
                        order.Quantity += 1;
                    }

                    await _context.SaveChangesAsync(); // Save changes to the database

                    return Ok("Order detail updated successfully");
                }
                else
                {
                    // If no existing order details found, create a new one
                    var newOrderDetail = new OrderDetail
                    {
                        Order_Id = orderDetail.OrderID,
                        Item_Id = orderDetail.ItemID,
                        Quantity = 1 // Assuming new order detail starts with a quantity of 1
                    };

                    _context.Order_Details.Add(newOrderDetail);
                    await _context.SaveChangesAsync(); // Save changes to the database

                    return Ok("New order detail added successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        public async Task<List<Order_detail>> GetAllOrderDetailInOrder(int OrderId)
        {
            try
            {
                var item = await _context.Order_Details.Where(i => i.Order_Id == OrderId).ToListAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve Item by ID", ex);
            }
        }
        public async Task<IEnumerable<Order_detail>> GetOrderDetailsByItemId(int itemId)
        {
            return await _context.Order_Details.Where(od => od.Item_Id == itemId).ToListAsync();
        }
    }
}
