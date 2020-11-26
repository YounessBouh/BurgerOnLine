using Microsoft.AspNetCore.Http;
using OnlineBurgerApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBurgerApp.Data.IServices
{
   public interface IProductService
    {
        IEnumerable<Product> getAll();
        Product getyId(int id);
        Task<int> Create(string Name, string Description, decimal Price, string Picture,List<IFormFile> pictures, int CategoryId);
        Task<int> Update(int id,string name, string description, decimal price, string picture, int categoryId);
        Task<bool> Delete(int id);
    }
}
