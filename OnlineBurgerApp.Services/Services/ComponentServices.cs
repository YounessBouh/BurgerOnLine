

using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBurgerApp.Data;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Data.Models;

namespace OnlineBurgerApp.Services.Services
{
    public class ComponentServices: IComponentService
    {
        private readonly ApplicationDbContext _db;
        public ComponentServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AddComponent(string PictureUrl, int ProductId)
        {
            var model = new Component {
                 ComponentUrl=PictureUrl,
                  ProductId=ProductId
            };

            _db.Components.Add(model);
            var val = await _db.SaveChangesAsync();
            if (val > 0)
                return true;
            return false;
             
        }

        public async Task<bool> Create(string PictureUrl,int x)
        {
            var model = new Component {
                 ComponentUrl=PictureUrl,
                  ProductId=x,
            };

            _db.Components.Add(model);
            var val = await _db.SaveChangesAsync();
            if (val > 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteCmp(int id)
        {
            var model = _db.Components.Find(id);
            if(model!=null)
            {
                _db.Components.Remove(model);
                var val = await _db.SaveChangesAsync();
                if (val > 0)
                    return true;
                return false;
            }
            return false;
        }

        public IEnumerable<Component> getAll()
        {
            return  _db.Components ;

        }

        public async Task<bool> UpdateCmp(int CompId, string PictureUrl)
        {
            var model = _db.Components.Find(CompId);
            if(model!=null)
            {
                model.ComponentUrl = PictureUrl;
                var val=await _db.SaveChangesAsync();
                if (val > 0)
                    return true;
                return false;
            }
            return true;
        }
    }
}
