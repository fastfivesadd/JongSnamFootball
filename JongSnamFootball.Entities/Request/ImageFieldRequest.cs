using System.ComponentModel.DataAnnotations;

namespace JongSnamFootball.Entities.Request
{
    public class ImageFieldRequest
    {
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
    }
}
