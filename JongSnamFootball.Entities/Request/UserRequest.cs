using System.ComponentModel.DataAnnotations;

namespace JongSnamFootball.Entities.Request
{
    public class UserRequest
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8,
            ErrorMessage = "Password should be minimum 8 characters and a maximum of 20 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8,
            ErrorMessage = "ConfirmPassword should be minimum 8 characters and a maximum of 20 characters")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [MaxLength(150)]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 9,
            ErrorMessage = "ContactMobile should be minimum 8 characters and a maximum of 10 characters")]
        [Phone]
        public string ContactMobile { get; set; }

        public string ImageProfile { get; set; }

        [Required]
        public int UserTypeId { get; set; }
    }
}
