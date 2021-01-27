using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class PictureFieldModel
    {
        [Column("id_picturefield")]
        public int Id { get; set; }

        [Column("id_field_in_picturefield")]
        public int IdField { get; set; }

        [Column("picture_picturefield")]
        public string Picture { get; set; }

        [Column("Date_picture")]
        public DateTime Date { get; set; }

    }
}
