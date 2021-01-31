using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class DiscountRequest
    {

        [Required(ErrorMessage = "StartDate is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        public DateTime? EndDate { get; set; }

        [Range(0,100)]
        [Required(ErrorMessage = "Percentage is required")]
        public double? Percentage { get; set; }

        [MaxLength(50)]
        public string Detail { get; set; }
    }
}
