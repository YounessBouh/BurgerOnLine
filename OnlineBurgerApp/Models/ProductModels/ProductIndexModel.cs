

using System.Collections.Generic;

namespace OnlineBurgerApp.Models.ProductModels
{
    public class ProductIndexModel
    {
        public IEnumerable<ProductListingModel> productIndexModels { get; set; }
        public IEnumerable<ProductCategoryModel> CategoryIndexModels { get; set; }

    }
}
