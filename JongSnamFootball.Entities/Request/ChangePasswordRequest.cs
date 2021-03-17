using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class ChangePasswordRequest
    {

        [Required]
        [StringLength(20, MinimumLength = 8,
        ErrorMessage = "Password should be minimum 8 characters and a maximum of 20 characters")]
        public string OldPassword { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 8,
        ErrorMessage = "Password should be minimum 8 characters and a maximum of 20 characters")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8,
            ErrorMessage = "ConfirmPassword should be minimum 8 characters and a maximum of 20 characters")]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
