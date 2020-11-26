

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlineBurgerApp.Data.Extensions.ModelValidations;

namespace OnlineBurgerApp.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredFieldErrMsg)]
        [MaxLength(30, ErrorMessage = MaxLengthErrorMsg)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredFieldErrMsg)]
        [MaxLength(800, ErrorMessage = MaxLengthDescriptionErrMsg)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredFieldErrMsg)]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredFieldErrMsg)]
        public string Picture { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<Component> Components { get; set; }
    }
}
