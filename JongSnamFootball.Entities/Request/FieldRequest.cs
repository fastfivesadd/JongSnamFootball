using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class FieldRequest
    {
        [Required(ErrorMessage = "IdStore is required")]
        public int IdStore { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Size is required")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

    }
}
