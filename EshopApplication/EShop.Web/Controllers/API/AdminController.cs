using EShop.Domain.Domain;
using EShop.Domain.DTO;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<EShopApplicationUser> _userManager;

        public AdminController(IOrderService orderService, UserManager<EShopApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetails(BaseEntity id)
        {
            return this._orderService.GetDetailsForOrder(id);
        }

        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> users)
        {
            bool status = true;

            foreach(var user in users)
            {
                var userCheck = _userManager.FindByEmailAsync(user.Email).Result;

                if (userCheck == null)
                {
                    var newUser = new EShopApplicationUser
                    {

                        FirstName = user.Email,
                        LastName = user.Email,
                        Address = user.Email,
                        UserCart = new ShoppingCart(),
                        UserName = user.Email,
                        NormalizedUserName = user.Email,
                        Email = user.Email,
                        EmailConfirmed = true

                    };
                    var result = _userManager.CreateAsync(newUser, user.Password).Result;
                    status = status && result.Succeeded;
                }
                else continue;
             
            }
            return status;
        }


    }
}
