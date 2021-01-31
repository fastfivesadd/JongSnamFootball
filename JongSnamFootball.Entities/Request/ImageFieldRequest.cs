using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class ImageFieldRequest
    {
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
    }
}
