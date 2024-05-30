using internship.Controllers.SubmitModels;
using internship.Models;
using internship.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ResModel> Search(SearchOrderForm searchOrderForm)
        {
            try
            {
                var result = await _unitOfWork.SearchOrder(searchOrderForm);
                if (result != null)
                {
                    return new ResModel(200, "Success", result);
                }
                else
                {
                    return new ResModel(404, "Not Found", null);
                }
            }
            catch (Exception ex)
            {
                return new ResModel(500, ex.Message, null);
            }
        }
    }
}
