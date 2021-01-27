using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class CommentModel
    {
        [Column("id_comment")]
        public int Id { get; set; }

        [Column("id_store_in_comment")]
        public int StoreId { get; set; }

        [Column("id_member_in_comment")]
        public int MemberId { get; set; }

        [Column("details_comment")]
        public string Detail { get; set; }

        [Column("rating_comment")]
        public decimal? Rating { get; set; }

        public virtual UserMemberModel UserModel { get; set; }

        public virtual StoreModel StoreModel { get; set; }
    }
}
