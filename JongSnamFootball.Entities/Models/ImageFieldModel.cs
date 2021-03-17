using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class ImageFieldModel : BaseModel
    {
        public int FieldId { get; set; }

        public string Image { get; set; }
    }
}
