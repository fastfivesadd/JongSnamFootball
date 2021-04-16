using System.Collections.Generic;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Entities.Dtos
{
    public class FieldDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string StoreName { get; set; }

        public string Size { get; set; }

        public bool IsOpen { get; set; }

        public bool Active { get; set; }

        public virtual StoreModel StoreModel { get; set; }

        public virtual ICollection<ImageFieldModel> ImageFieldModel { get; set; }



    }
}
