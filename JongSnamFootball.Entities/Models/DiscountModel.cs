using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class DiscountModel : BaseModel
    {
        public int FieldId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Percentage { get; set; }

        public string Detail { get; set; }

    }
}
