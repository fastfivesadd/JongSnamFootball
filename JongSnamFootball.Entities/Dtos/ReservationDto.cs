using System;

namespace JongSnamFootball.Entities.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public bool ApprovalStatus { get; set; }

        public string UserName { get; set; }

        public string StoreName { get; set; }

        public string ContactMobile { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }

        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
