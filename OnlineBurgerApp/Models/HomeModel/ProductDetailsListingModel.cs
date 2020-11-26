

using System.Collections.Generic;

namespace OnlineBurgerApp.Models.HomeModel
{
    public class ProductDetailsListingModel
    {
        public ProductListingModel product { get; set; }
        public IEnumerable<ComponentListingModel> components { get; set; }
    }
}
