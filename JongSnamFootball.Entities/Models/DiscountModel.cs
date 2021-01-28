using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class DiscountModel
    {
        [Column("id_discount")]
        public int Id { get; set; }

        [Column("id_field_in_discount")]
        public int IdField { get; set; }

        [Column("startTime_discount")]
        public DateTime StartTime { get; set; }

        [Column("endTime_discount")]
        public DateTime EndTime { get; set; }

        [Column("percentage_discount")]
        public float Percentage { get; set; }

        [Column("detail_discount")]
        public string Detail { get; set; }

    }
}
