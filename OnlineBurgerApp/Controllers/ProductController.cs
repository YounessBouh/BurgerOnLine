
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Models.ProductModels;

namespace OnlineBurgerApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _IProductService;
        private readonly ICategoryService _ICategoryService;
        private readonly IComponentService _IComponentService;

        public ProductController(IProductService IProductService, ICategoryService ICategoryService,
            IComponentService IComponentService)
        {
            _IProductService = IProductService;
            _ICategoryService = ICategoryService;
            _IComponentService = IComponentService;
        }

        public IActionResult Index()
        {
            var list1 = _IProductService.getAll().
                Select(p => new ProductListingModel {

                    Id=p.Id,
                    Name=p.Name,
                    Description=p.Description,
                    Price=p.Price,
                    Picture=p.Picture
                });

            var list2 = _ICategoryService.getAll()
                .Select(c => new ProductCategoryModel
                 {
                     CategoryId = c.CategoryId,
                     Name=c.Name
                 });

            var model = new ProductIndexModel {
                productIndexModels = list1,
                CategoryIndexModels = list2
            }; 

            return View(model);
        }


        public async Task<JsonResult> Action(ProductRequestModel model)
        {
            if(model.Picture!=null && model.Picture.Length>0 &&model.Pictures!=null && model.Pictures.Count>0)
            {
                var ProductFileName = Guid.NewGuid() + Path.GetExtension(model.Picture.FileName);
                var ProductFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Pictures", ProductFileName);
                using (var fileStream = new FileStream(ProductFilePath, FileMode.Create))
                {
                    await model.Picture.CopyToAsync(fileStream);
                }

                if (model.Id == 0)
                {
                    var x = await _IProductService.Create(model.Name, model.Description, model.Price, ProductFileName,model.Pictures, model.CategoryId);
                    if (x>0)
                    {
                        return Json(true);
                    }
                       
                    return Json(false);
                }
                else
                {                   
                    var x = await _IProductService.Update(model.Id,model.Name, model.Description, model.Price, ProductFileName, model.CategoryId);
                    if (x>0)
                        return Json(true);
                    return Json(false);
                }             
            }

            else if(model.Picture==null && model.Id>0)
            {
                var p = _IProductService.getyId(model.Id);
                if (p == null)
                    return Json(false);
                var y = await _IProductService.Update(model.Id, model.Name, model.Description, model.Price, p.Picture, model.CategoryId);
                if (y>0)
                    return Json(true);
                return Json(false);

            }

           
            return Json(false);
        }
        public JsonResult getById(int Id)
        {
            if(Id>0)
            {
                var p = _IProductService.getyId(Id);
                if (p == null)
                    return Json(null);
                return Json(p);
            }
            return Json(null);
        }

        public async Task<JsonResult> Delete(int id)
        {
            if(id>0)
            {
                var Oper = await _IProductService.Delete(id);
                if (Oper)
                    return Json(true);
                return Json(false);
            }
            return Json(false);
        }

        public JsonResult Details(int id)
        {
            if(id>0)
            {
                var rez = _IComponentService.getAll().Where(x=>x.ProductId==id).ToList();


                var list = JsonConvert.SerializeObject(rez,
                   Formatting.None,
                  new JsonSerializerSettings()
                  {
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  });

                return Json(list);
            }
            return Json(null);
        }

        public async Task<JsonResult> CreateCmp(IFormFile PictureUrl,int ProductId )
        {
           if(PictureUrl!=null && PictureUrl.Length>0 && ProductId>0 )
            {
                var ComponentFileName = Guid.NewGuid() + Path.GetExtension(PictureUrl.FileName);
                var ProductFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Pictures", ComponentFileName);
                using (var fileStream = new FileStream(ProductFilePath, FileMode.Create))
                {
                    await PictureUrl.CopyToAsync(fileStream);
                }

                var rez = await _IComponentService.AddComponent(ComponentFileName, ProductId);
                if (rez)
                    return Json(true);
                return Json(false);
            }
            return Json(false);
        }

        public async Task<JsonResult> DeleteCmp(int id)
        {
            if(id>0)
            {
                var rez = await _IComponentService.DeleteCmp(id);
                if (rez)
                    return Json(true);
                return Json(false);
            }
            return Json(false)
;
        }

        public async Task<JsonResult> UpdateCmp(int CompId, IFormFile PictureUrl)
        {
            if (PictureUrl != null && PictureUrl.Length>0 && CompId>0)
            {
                var ComponentFileName = Guid.NewGuid() + Path.GetExtension(PictureUrl.FileName);
                var ProductFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Pictures", ComponentFileName);
                using (var fileStream = new FileStream(ProductFilePath, FileMode.Create))
                {
                    await PictureUrl.CopyToAsync(fileStream);
                }

                var rez = await _IComponentService.UpdateCmp(CompId, ComponentFileName);
                if (rez)
                    return Json(true);
                return Json(false);

            }
            return Json(false);
        }



    }
}