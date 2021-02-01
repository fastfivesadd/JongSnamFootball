namespace JongSnamFootball.Entities.Request
{
    public class SearchFieldRequest
    {
        public decimal? StartPrice { get; set; }

        public decimal? ToPrice { get; set; }

        public string Amphur { get; set; }

        public string Province { get; set; }
    }
}
