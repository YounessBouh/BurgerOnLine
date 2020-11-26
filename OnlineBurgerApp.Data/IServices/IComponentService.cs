
using OnlineBurgerApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBurgerApp.Data.IServices
{
   public interface IComponentService
    {
         IEnumerable<Component> getAll();
        Task<bool> Create(string files,int x);
        Task<bool> AddComponent(string PictureUrl, int ProductId);
        Task<bool> DeleteCmp(int id);
        Task<bool> UpdateCmp(int  CompId,string PictureUrl);


    }

    
}
