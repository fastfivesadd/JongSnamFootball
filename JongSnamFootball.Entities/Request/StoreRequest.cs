using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class StoreRequest
    {

        [Required(ErrorMessage = "Owner is required")]
        public int Owner { get; set; }

        public string Picture { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "OtherAddress is required")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string OtherAddress { get; set; }

        [Required(ErrorMessage = "DistrictAddress is required")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string DistrictAddress { get; set; }

        [Required(ErrorMessage = "AmphurAddress is required")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string AmphurAddress { get; set; }

        [Required(ErrorMessage = "ProvinceAddress is required")]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string ProvinceAddress { get; set; }

        [Required(ErrorMessage = "TelePhone is required")]
        [StringLength(10, MinimumLength = 9,
            ErrorMessage = "Telephone should be minimum 8 characters and a maximum of 10 characters")]
        [Phone]
        public string TelePhone { get; set; }

 
        public decimal? Latitude { get; set; }

        public decimal? Longtitude { get; set; }

        [MaxLength(150)]
        public string OfficeHours { get; set; }

        [Required]
        [StringLength(5)]
        public string Status { get; set; }

        [MaxLength(50)]
        public string? Rules { get; set; }



    }
}
