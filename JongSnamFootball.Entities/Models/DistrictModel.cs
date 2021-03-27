namespace JongSnamFootball.Entities.Models
{
    public class DistrictModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public virtual ProvinceModel ProvinceModel { get; set; }

    }
}
