using System;

namespace JongSnamFootball.Entities.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        public decimal Rating { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual UserModel UserModel { get; set; }

        public virtual StoreModel StoreModel { get; set; }
    }
}
