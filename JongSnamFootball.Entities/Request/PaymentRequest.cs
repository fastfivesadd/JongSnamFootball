﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Request
{
    public class PaymentRequest
    {
        public int ReservationId { get; set; }

        public string Image { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool IsFullAmount { get; set; }
    }
}