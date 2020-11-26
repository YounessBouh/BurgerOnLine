

namespace OnlineBurgerApp.Models.HomeModel
{
    public class ProductModelSession
    {
       
        public int Id { get; set; }

       
        public string Name { get; set; }

       
        public string Description { get; set; }

        
        public decimal Price { get; set; }

       
        public string Picture { get; set; }


        public int CategoryId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Total { get; set; }

    }
}

