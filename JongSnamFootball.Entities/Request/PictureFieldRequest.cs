using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class PictureFieldRequest
    {


        [Required(ErrorMessage = "Picture is required")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
    }
}
