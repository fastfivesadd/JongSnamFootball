using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Entities.Request
{
    public class UpdateReservationRequest
    {
        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }
    }
}
