using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class PaymentModel
    {
        [Column("id_payment")]
        public int Id { get; set; }

        [Column("id_reservation_in_payment")]
        public int IdReservation { get; set; }

        [Column("picture_payment")]
        public string Picture { get; set; }

        [Column("amount_payment")]
        public float Amount { get; set; }

        [Column("date_payment")]
        public DateTime Date { get; set; }

        [Column("status_payment")]
        public int Status { get; set; }

        [Column("status_amount_payment")]
        public int StatusAmount { get; set; }
    }
}
