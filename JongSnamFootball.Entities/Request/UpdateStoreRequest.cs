using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class UpdateStoreRequest 
    {
        public string Image { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "District is required")]
        public int SubDistrict { get; set; }

        [Required(ErrorMessage = "Amphur is required")]
        public int District { get; set; }

        [Required(ErrorMessage = "Province is required")]
        public int Province { get; set; }

        [Required(ErrorMessage = "ContactMobile is required")]
        [StringLength(10, MinimumLength = 9,
            ErrorMessage = "ContactMobile should be minimum 8 characters and a maximum of 10 characters")]
        [Phone]
        public string ContactMobile { get; set; }


        public decimal? Latitude { get; set; }

        public decimal? Longtitude { get; set; }

        [MaxLength(150)]
        public string OfficeHours { get; set; }

        [Required]
        public bool IsOpen { get; set; }

        [MaxLength(50)]
        public string Rules { get; set; }
    }
}
