using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MyBecoffe.Models
{
    public class Becoffe
    {
        
        public int Id {get; set;}

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string? firstName {get; set;}

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string? lastName {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? email {get; set;}

        [Required]
        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string? password {get; set;}

        [Required]
        public string account_type {
            get{return account_type;} 
            set{account_type = value;}
        }

    }
}