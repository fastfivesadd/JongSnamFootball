using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class FieldModel : BaseModel
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public bool IsOpen { get; set; }

        public bool Active { get; set; }

        public virtual StoreModel StoreModel { get; set; }
        
        public virtual DiscountModel DiscountModel { get; set; }

        public virtual ICollection<ImageFieldModel> ImageFieldModel { get; set; }

    }
}
