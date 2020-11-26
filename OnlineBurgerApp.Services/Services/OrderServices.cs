

using System;
using OnlineBurgerApp.Data;
using System.Threading.Tasks;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Data.Models;
using System.Collections.Generic;


namespace OnlineBurgerApp.Services.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ApplicationDbContext _db;

        public OrderServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddCustomerInfo(string CustomerName, string CustomerAddress, string CustomerPhone, string CustomerEmail, List<object> products )
        {

            var orderDetailsList = new List<OrderDetails>();
            
            var model = new Order {
                CustomerName = CustomerName,
                CustomerAddress = CustomerAddress,
                CustomerPhone = CustomerPhone,
                CustomerEmail = CustomerEmail,
                OrderNumber = "1718178",
                OrderDate = DateTime.Now.ToString("d")
            };

           
            foreach(var p in products)
            {
              var orderDetails = new OrderDetails();
              orderDetails.ProductId= (int) p.GetType().GetProperty("Id").GetValue(p,null);
              orderDetails.Quantity = (decimal)p.GetType().GetProperty("Quantity").GetValue(p, null);
              orderDetails.UnitPrice = (decimal) p.GetType().GetProperty("Price").GetValue(p, null);
              orderDetails.TotalPrice = (decimal)p.GetType().GetProperty("Total").GetValue(p, null);
              orderDetailsList.Add(orderDetails);
            }

            model.OrederDetails = orderDetailsList;
            _db.Orders.Add(model);
            int val = await _db.SaveChangesAsync();

            if (val > 0)
                return model.OrderId;
            return 0;
        }
        
    }
}
