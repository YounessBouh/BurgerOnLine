

using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBurgerApp.Models.OrderModels
{
    public class OrderListingModel
    {

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(12)]
        public string CustomerPhone { get; set; }


        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(30)]
        public string CustomerEmail { get; set; }

    }
}
