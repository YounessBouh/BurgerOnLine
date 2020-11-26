

using OnlineBurgerApp.Data.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBurgerApp.Data.IServices
{
    public interface IOrderServices
    {
        Task<int> AddCustomerInfo(string CustomerName, string CustomerAddress, string CustomerPhone, string CustomerEmail, List<object> products);
       
    }
}
