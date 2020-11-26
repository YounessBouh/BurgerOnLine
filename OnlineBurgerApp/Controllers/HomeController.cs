
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Extensions;
using OnlineBurgerApp.Models;
using OnlineBurgerApp.Models.HomeModel;

namespace OnlineBurgerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _IProductService;
        private readonly ICategoryService _ICategoryService;
        private readonly IComponentService _IComponentService;

        private List<ProductModelSession> products=new List<ProductModelSession>();

        public HomeController(IProductService IProductService, ICategoryService ICategoryService,
            IComponentService IComponentService)
        {
            _ICategoryService = ICategoryService;
            _IProductService = IProductService;
            _IComponentService = IComponentService;
        }

        public IActionResult Index()
        {
           

            var List1 = _IProductService.getAll().Select( p => new HomeProductListingModel {
                 Id=p.Id,
                 CategoryId=p.CategoryId,
                 Description=p.Description,
                 Name=p.Name,
                 Picture=p.Picture,
                 Price=p.Price
            });

            var List2 = _ICategoryService.getAll().Select(cat => new HomeCategoryListingModel {

                 CategoryId=cat.CategoryId,
                 Name=cat.Name
            });

            var list3 = _IComponentService.getAll().Select(comp =>new HomeComponentsListingModel {
                 ComponentId=comp.ComponentId,
                 ComponentUrl=comp.ComponentUrl,
                 ProductId=comp.ProductId
            });


            var model = new HomeIndexModel {                
                ProductListing=List1,
                CategoryListing = List2,
                ComponentListing =list3
            };


            return View(model);
        }

      
        public JsonResult AddToCart(int id)
        {
           

            if(id==0)
            {
                return Json(false);
            }

            var model = _IProductService.getyId(id);
            

            if(model==null)
            {
                  return Json(false);
            }

            products = HttpContext.Session.Get<List<ProductModelSession>>("Cart");
            if(products==null)
            {
                products = new List<ProductModelSession>();
            }
            if (products.Any(x => x.Id  == id))
            {
                var prod = products.FirstOrDefault(p =>p.Id==id);
                prod.Quantity++;
                prod.Total = prod.Price * prod.Quantity;
            }
            else
            {
                var obj = new ProductModelSession
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Picture = model.Picture,
                    CategoryId = model.CategoryId,
                    Quantity = 1,
                    Total = model.Price
                };

                products.Add(obj);
            }

            
            HttpContext.Session.Set("Cart", products);
            HttpContext.Session.Set("Total", products.Sum(p=>p.Total));
            return Json(true);
        }



        public ActionResult checkout()
        {
            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            var pModel = _IProductService.getyId(id);
            var ProductModel = new ProductListingModel {
                Id=pModel.Id,
                Description=pModel.Description,
                Name=pModel.Name,
                Picture=pModel.Picture,
                Price=pModel.Price
            };

            var ComponentModel = _IComponentService.getAll()
                                  .Where(p => p.ProductId == id)
                                  .Select(p => new ComponentListingModel
                                  {
                                        ComponentId=p.ComponentId,
                                        ComponentUrl=p.ComponentUrl,
                                        ProductId=p.ProductId
                                  });



            var model = new ProductDetailsListingModel {
                 product= ProductModel,
                 components=ComponentModel
            };

            return View(model);
        }


       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
