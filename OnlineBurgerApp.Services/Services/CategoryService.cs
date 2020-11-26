


using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineBurgerApp.Data;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Data.Models;

namespace OnlineBurgerApp.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(string name)
        {
                var cat = new Category
                {
                    Name = name
                };

                _db.Categories.Add(cat);
                var val=   await _db.SaveChangesAsync();

                if(val>0)
                     return true;
                else
                     return false;      
        }

        public async Task<bool> Delete(int id)
        {
            var model = await _db.Categories.FindAsync(id);
            if (model == null)
                return false;
              _db.Categories.Remove(model);
            var val = await _db.SaveChangesAsync();
            if(val>0)
                return true;
            else
                return false;
        }

       
        public IEnumerable<Category> getAll()
        {
            return _db.Categories;
        }

        public Category getById(int id)
        {
            var model= _db.Categories.Find(id);
            if(model!=null)
                return model;
            return null;
        }


        public async Task<bool> Update(int id, string name)
        {           
            var model = _db.Categories.Find(id);
            if(model==null)
                return false;
           
            model.Name = name;
            
            var val = await _db.SaveChangesAsync();
            if (val > 0)
                return true;
            else
                return false;

        }
    }
}
