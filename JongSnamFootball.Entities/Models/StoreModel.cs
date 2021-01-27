using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class StoreModel
    {
        [Column("id_store")]
        public int Id { get; set; }

        [Column("owner_store")]
        public int Owner { get; set; }

        [Column("name_store")]
        public string Name { get; set; }

        [Column("other_addr_store")]
        public string OtherAddress { get; set; }

        [Column("district_addr_store")]
        public string DistrictAddress { get; set; }

        [Column("amphur_addr_store")]
        public string AmphurAddress { get; set; }

        [Column("province_addr_store")]
        public string ProvinceAddress { get; set; }

        [Column("telephone_store")]
        public string TelePhone { get; set; }

        [Column("latitude_store")]
        public decimal? Latitude { get; set; }

        [Column("longitude_store")]
        public decimal? Longtitude { get; set; }

        [Column("rules_store")]
        public string Rules { get; set; }

        [Column("picture_store")]
        public string Picture { get; set; }

        [Column("rating")]
        public decimal? Rating { get; set; }

        [Column("status_store")]
        public string Status { get; set; }

        [Column("office_hours_store")]
        public string OfficeHours { get; set; }

        //public virtual List<CommentModel> CommentModel { get; set; }
    }
}
