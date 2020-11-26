

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlineBurgerApp.Data;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Data.Models;

namespace OnlineBurgerApp.Services.Services
{
    public class ProductService : IProductService
    {
        public readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(string name,string description,decimal price,string picture, List<IFormFile> pictures, int categoryId)
        {
            int x = 0;
           

            var model = new Product {
              Name=name,
              Description= description,
              Price=price,
              Picture=picture,
              CategoryId=categoryId,
              Category=_db.Categories.Find(categoryId) 
            };

            var componentModel = new List<Component>();
            for (int i = 0; i < pictures.Count; i++)
            {
                var ComponentFileName = Guid.NewGuid() + Path.GetExtension(pictures[i].FileName);
                var ComponentFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Pictures", ComponentFileName);
                using (var fileStream = new FileStream(ComponentFilePath, FileMode.Create))
                {
                    await pictures[i].CopyToAsync(fileStream);
                }

                componentModel.Add(new Component() { 
                    ComponentUrl= ComponentFileName        
                });

            }

            model.Components = componentModel;

            _db.Products.Add(model);

            var val = await _db.SaveChangesAsync();
            if (val > 0)
                return model.Id;
            return x;
            
        }

        public async Task<bool> Delete(int id)
        {
            var model = _db.Products.Find(id);
            if (model == null)
                return false;
            _db.Products.Remove(model);
            var val = await _db.SaveChangesAsync();
            if (val > 0)
                return true;
            return false;    
        }

        public IEnumerable<Product> getAll()
        {
           return _db.Products;
        }

        public Product getyId(int id)
        {
            var model = _db.Products.Find(id);
            if (model == null)
                return null;
            return model;
        }

        public async Task<int> Update(int id, string name, string description, decimal price, string picture, int categoryId)
        {
            int x = 0;
            var model = _db.Products.Find(id);
            if (model == null)
                return x;
            model.Name = name;
            model.Description = description;
            model.Price = price;
            model.Picture = picture;
            model.CategoryId = categoryId;
            model.Category = _db.Categories.Find(categoryId);

            var val = await _db.SaveChangesAsync();
            if (val > 0)
                return id;
            return x;
        }

        public async Task<bool> save()
        {
          var val=  await _db.SaveChangesAsync();
            if (val > 0)
                return true;
            return false;
        }

       
    }
}
