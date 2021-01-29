using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Dtos
{
    public class DetailReservationDto
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public string NameUser { get; set; }

        public string TelePhone { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }

        public string NameField { get; set; }

        public int PriceField { get; set; }
        
        public string StatusAmount { get; set; }

        public string StatusPayment { get; set; }

        public double AmountPayment { get; set; }
    }
}
