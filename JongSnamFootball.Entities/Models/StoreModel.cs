using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class StoreModel : BaseModel
    {
        public int OwnerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public string Amphur { get; set; }

        public string Province { get; set; }

        public string ContactMobile { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longtitude { get; set; }

        public string Rules { get; set; }

        public string Image { get; set; }

        public bool IsOpen { get; set; }

        public string OfficeHours { get; set; }
    }
}
