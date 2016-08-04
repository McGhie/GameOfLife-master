using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gameoflife.Models
{

   
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

      
        [Required(ErrorMessage = "The first name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength =2)]
        [Display(Name = "Last Name")]
        public string LastName{ get; set; }




    }

    public class UserTemplateMetadata
    {
        [Required]
        public string Name { get; set;}

        [Required, Range(1, 20)]
        public string Width { get; set; }
        [Required, Range(1, 20)]
        public string Height { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string Cells { get; set; }

    }

    namespace Models 
    {
        [MetadataType(typeof(RegisterViewModel))]
        public partial class User
        {}
        [MetadataType(typeof(UserTemplateMetadata))]
        public partial class UserTemplate
        { }


    }



 
}
