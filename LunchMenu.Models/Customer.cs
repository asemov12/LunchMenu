using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username should be between 3 and 50 characters long")]
        [RegularExpression(@"^\w+$", ErrorMessage = "Username must contain only letters, numbers, and underscores")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^[a-fA-F0-9]{64}$", ErrorMessage = "Password hash must be 64 hex characters")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [RegularExpression("^(regular|bringer)$", ErrorMessage = "Type must be 'regular' or 'bringer'")]
        public string Type { get; set; }
    }
}
