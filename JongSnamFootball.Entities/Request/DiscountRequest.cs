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

        [Required(ErrorMessage = "StartTime is required")]
        public DateTime? StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required")]
        public DateTime? EndTime { get; set; }

        [Range(0,100)]
        [Required(ErrorMessage = "Percentage is required")]
        public decimal? Percentage { get; set; }

        [MaxLength(50)]
        public string? Detail { get; set; }
    }
}
