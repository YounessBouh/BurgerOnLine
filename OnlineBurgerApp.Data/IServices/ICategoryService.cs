

using OnlineBurgerApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBurgerApp.Data.IServices
{
   public interface ICategoryService
    {
        IEnumerable<Category> getAll();
        Category getById(int id);
        Task<bool> Create(string name);
        Task<bool> Delete(int id);
        Task<bool> Update(int id,string name);
       
    }
}
