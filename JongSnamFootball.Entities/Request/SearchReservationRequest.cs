namespace JongSnamFootball.Entities.Request
{
    public class SearchReservationRequest
    {
        public DateTimeRequest StartTime { get; set; }

        public DateTimeRequest StopTime { get; set; }

        public string UserName { get; set; }

        public string StoreName { get; set; }

    }
}
