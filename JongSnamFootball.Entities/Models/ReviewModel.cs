using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class ReviewModel : BaseModel
    {
        public int StoreId { get; set; }

        public int MemberId { get; set; }

        public string Message { get; set; }

        public decimal Rating { get; set; }

        public virtual UserModel UserModel { get; set; }

        public virtual StoreModel StoreModel { get; set; }
    }
}
