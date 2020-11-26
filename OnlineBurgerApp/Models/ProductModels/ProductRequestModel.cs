using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBurgerApp.Models.ProductModels
{
    public class ProductRequestModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public IFormFile Picture { get; set; }

        //[NotMapped]
        public List<IFormFile> Pictures { get; set; }
    }
}
