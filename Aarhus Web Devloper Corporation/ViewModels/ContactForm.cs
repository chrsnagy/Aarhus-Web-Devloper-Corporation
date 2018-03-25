using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aarhus_Web_Devloper_Corporation.ViewModels
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Enter correct email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please enter Message")]
        public string Message { get; set; }
    }
}