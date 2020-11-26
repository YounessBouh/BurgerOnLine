

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlineBurgerApp.Data.Extensions.ModelValidations;

namespace OnlineBurgerApp.Data.Models
{
    public class Component
    {
        [Key]
        public int ComponentId { get; set; }

        [Required(ErrorMessage = RequiredFieldErrMsg)]
        public string ComponentUrl { get; set; }


        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
