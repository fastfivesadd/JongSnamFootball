using System.ComponentModel.DataAnnotations;

namespace JongSnamFootball.Entities.Request
{
    public class FieldRequest
    {
        [Required(ErrorMessage = "StoreId is required")]
        public int StoreId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Size is required")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        public bool IsOpen { get; set; }

        public bool Active { get; set; }
    }
}
