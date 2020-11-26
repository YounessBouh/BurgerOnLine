

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBurgerApp.Data.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public decimal UnitPrice { get; set; }

        [Required]
        [MaxLength(100)]
        public decimal Quantity { get; set; }


        [Required]
        [MaxLength(100)]
        public decimal TotalPrice { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order order { get; set; }
    }
}
