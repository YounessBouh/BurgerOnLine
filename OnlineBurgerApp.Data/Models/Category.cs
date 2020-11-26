using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static OnlineBurgerApp.Data.Extensions.ModelValidations;
namespace OnlineBurgerApp.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = RequiredFieldErrMsg)]
        [MaxLength(30, ErrorMessage = MaxLengthErrorMsg)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
