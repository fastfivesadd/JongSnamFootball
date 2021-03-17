using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class PaymentModel : BaseModel
    {
        public int ReservationId { get; set; }

        public string Image { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool IsFullAmount { get; set; }

        //public virtual ICollection<ReservationModel> ReservationModel { get; set; }
    }
}
