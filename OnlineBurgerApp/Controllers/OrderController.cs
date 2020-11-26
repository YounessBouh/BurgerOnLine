
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Extensions;
using OnlineBurgerApp.Models.HomeModel;
using OnlineBurgerApp.Models.OrderModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBurgerApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _IOrdeeService;
        private readonly IProductService _IProductService;

        public OrderController(IOrderServices OrdeeService, IProductService IProductService)
        {
            _IOrdeeService = OrdeeService;
            _IProductService = IProductService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Order(OrderListingModel order)
        {
            List<ProductModelSession> products = HttpContext.Session.Get<List<ProductModelSession>>("Cart");
            List<object> Productlist = new List<object>();

            foreach(var prod in products )
            {
                var p = new { Id = prod.Id, Quantity= prod.Quantity, Price= prod.Price, Total = prod.Total };
                Productlist.Add(p);
            }

            var OrderId = await _IOrdeeService.AddCustomerInfo(order.CustomerName, order.CustomerAddress, order.CustomerPhone, order.CustomerEmail, Productlist);
            if (OrderId > 0)
            {
 
                HttpContext.Session.Clear();
                return Json(true);
            }

            return Json(false);
        }

        public JsonResult delete(int Id)
        {
           if(Id==0)
            {
                return Json(false);
            }
            var prod = _IProductService.getyId(Id);
            if(prod==null)
            {
                Json(false);
            }

            List<ProductModelSession> products = HttpContext.Session.Get<List<ProductModelSession>>("Cart");

            ProductModelSession model = products.First(x => x.Id == prod.Id);
            products.Remove(model);
            HttpContext.Session.Set("Cart", products);
            HttpContext.Session.Set("Total", products.Sum(p => p.Total));
            return Json(true);
        }
    }
}