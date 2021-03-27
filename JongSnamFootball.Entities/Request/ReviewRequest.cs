using System.ComponentModel.DataAnnotations;

namespace JongSnamFootball.Entities.Request
{
    public class ReviewRequest
    {
        [Required(ErrorMessage = "StoreId is required")]
        public int StoreId { get; set; }

        [Required(ErrorMessage = "MemberId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public decimal Rating { get; set; }
    }
}
