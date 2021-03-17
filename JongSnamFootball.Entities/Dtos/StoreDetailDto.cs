using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Dtos
{
    public class StoreDetailDto
    {
        public int OwnerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int SubDistrictId { get; set; }

        public int DistrictId { get; set; }

        public int ProvinceId { get; set; }

        public string ContactMobile { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longtitude { get; set; }

        public string Rules { get; set; }

        public string Image { get; set; }

        public bool IsOpen { get; set; }

        public string OfficeHours { get; set; }
    }
}
