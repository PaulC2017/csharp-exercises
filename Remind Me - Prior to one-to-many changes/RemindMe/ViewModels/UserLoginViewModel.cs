﻿using System.ComponentModel.DataAnnotations;

namespace RemindMe.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "A User Name is Required")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A password is Required")]
        [Display(Name = "Password")]
        [StringLength(15, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Verify password Must Match password")]
        [Display(Name = "Verify Password")]
        [Compare("Password")]
        public string VerifyPassword { get; set; }
        
        public int UserId { get; set; }

    }
}
