using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class FieldModel
    {
        [Column("id_field")]
        public int Id { get; set; }

        [Column("id_store_in_field")]
        public int IdStore { get; set; }

        [Column("name_field")]
        public string Name { get; set; }

        [Column("discount_field")]
        public string Discount { get; set; }

        [Column("size_field")]
        public string Size { get; set; }

        [Column("price_field")]
        public int Price { get; set; }

        [Column("status_field")]
        public string Status { get; set; }

    }
}
