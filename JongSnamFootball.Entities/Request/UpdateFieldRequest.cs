using System.Collections.Generic;

namespace JongSnamFootball.Entities.Request
{
    public class UpdateFieldRequest : FieldRequest
    {
        public UpdateDiscountRequest UpdateDiscountRequest { get; set; }

        public ICollection<UpdatePictureFieldRequest> UpdatePictureFieldRequest { get; set; }
    }
}
