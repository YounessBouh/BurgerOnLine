
using Microsoft.AspNetCore.Mvc;
using OnlineBurgerApp.Data.IServices;
using OnlineBurgerApp.Models.CategoryModels;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBurgerApp.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategoryService _ICategoryService;
        public CategoryController(ICategoryService ICategoryService)
        {
            _ICategoryService = ICategoryService;
        }
        public IActionResult Index()
        {
            var list = _ICategoryService.getAll()
                .Select(c => new CategoryListingModel
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                });

            var model = new CategoryIndexModel
            {
                CategoryListingModel = list
            };

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> Action(CategoryRequestModel model)
        { 
            if(model.Name!=null)
            {
                if (model.CategoryId != 0 )
                {
                    var x = await _ICategoryService.Update(model.CategoryId, model.Name);
                    if (x)
                        return Json(true);
                    else
                        return Json(false);
                }
                else
                {
                    var y = await _ICategoryService.Create(model.Name);
                    if (y)
                        return Json(true);
                    
                    return Json(false);
                }
            }

            return Json(false);
           
        }

        [HttpGet]
        public  JsonResult getElementById(int Id)
        {
            if(Id>0)
            {
                var model =  _ICategoryService.getById(Id);

                if(model!=null)          
                    return Json(model); 
                return Json(null);
            }
            return Json(null);
        }


        [HttpPost]
        public async Task<JsonResult> Delete(int Id)
        {
            if (Id > 0)
            {
                var Oper = await _ICategoryService.Delete(Id);
                if (!Oper)
                    return Json(false);
                return Json(true);  
            }
           
            return Json(false);
        }
    }
}