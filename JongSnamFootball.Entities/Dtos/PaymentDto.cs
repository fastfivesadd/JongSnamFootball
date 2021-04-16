using System;

namespace JongSnamFootball.Entities.Dtos
{
    public class PaymentDto
    {
        public int ReservationId { get; set; }

        public string Image { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool IsFullAmount { get; set; }
    }
}
