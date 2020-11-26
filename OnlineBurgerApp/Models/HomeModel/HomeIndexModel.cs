

using System.Collections.Generic;

namespace OnlineBurgerApp.Models.HomeModel
{
    public class HomeIndexModel
    {
        public IEnumerable<HomeProductListingModel> ProductListing { get; set; }
        public IEnumerable<HomeCategoryListingModel> CategoryListing { get; set; }
        public IEnumerable<HomeComponentsListingModel> ComponentListing { get; set; }

    }
}
