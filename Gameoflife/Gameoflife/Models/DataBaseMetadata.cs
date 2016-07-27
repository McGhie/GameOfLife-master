﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gameoflife.Models
{

   
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

      
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Last Name")]
        public string LastName{ get; set; }




    }

    namespace Models 
    {
        [MetadataType(typeof(RegisterViewModel))]
        
        public partial class User
        {
            
        }

    

    }



 
}
