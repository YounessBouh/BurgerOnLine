

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineBurgerApp.Data.Models
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(12)]
        public string CustomerPhone { get; set; }


        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(40)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(30)]
        public string OrderDate { get; set; }

        [Required]
        [MaxLength(30)]
        public string OrderNumber { get; set; }

        public List<OrderDetails> OrederDetails { get; set; }
    }
}
