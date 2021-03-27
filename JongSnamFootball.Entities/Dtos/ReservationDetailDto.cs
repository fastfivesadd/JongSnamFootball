using System;
using System.Collections.Generic;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Entities.Dtos
{
    public class ReservationDetailDto
    {
        public int Id { get; set; }

        public bool ApprovalStatus { get; set; }

        public string UserName { get; set; }

        public string StoreName { get; set; }

        public string ContactMobile { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }

        public string FieldName { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsFullAmount { get; set; }

        public IEnumerable<PaymentModel> PaymentModel { get; set; }

        public decimal AmountForPay { get; set; }
    }
}
