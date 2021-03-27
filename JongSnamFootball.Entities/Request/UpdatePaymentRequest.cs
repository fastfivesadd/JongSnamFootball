using System;

namespace JongSnamFootball.Entities.Request
{
    public class UpdatePaymentRequest
    {
        public string Image { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool IsFullAmount { get; set; }
    }
}
