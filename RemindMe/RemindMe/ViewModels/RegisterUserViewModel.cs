using System.ComponentModel.DataAnnotations;



namespace RemindMe.ViewModels
{
    public class RegisterUserViewModel
    {
        
        [Required(ErrorMessage = "A User Name is Required")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A Password of at least 6 characters is Required")]
        [Display(Name = "Password")]
        [StringLength(10, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Verify Password Must Match Password")]
        [Display(Name = "Verify Password")]
        [Compare("Password")]
        public string Verify { get; set; }

        [Required(ErrorMessage = "An Email is Required")]
        [Display(Name = "Enter the Email associated with your Google Calendar")]
        [EmailAddress]
        public string Email { get; set; }

        public string CreateDate { get; set; }

        public int UserId { get; set; }

    } 
}
