using System.Collections.Generic;

namespace JongSnamFootball.Entities.Request
{
    public class AddFieldRequest
    {
        public FieldRequest FieldRequest { get; set; }
        public DiscountRequest DiscountRequest { get; set; }

        public ICollection<ImageFieldRequest> PictureFieldRequest { get; set; }
    }
}
