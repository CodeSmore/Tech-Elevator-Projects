using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "First Name must be 20 characters or less")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Last Name must be 20 characters or less")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or more")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Number of Tickets must be between 1 and 10")]
        public int Tickets { get; set; }
    }
}