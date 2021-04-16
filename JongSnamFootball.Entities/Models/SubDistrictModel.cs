namespace JongSnamFootball.Entities.Models
{
    public class SubDistrictModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int DistrictId { get; set; }

        public virtual DistrictModel DistrictModel { get; set; }
    }
}
