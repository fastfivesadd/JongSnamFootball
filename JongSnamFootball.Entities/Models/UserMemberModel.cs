using System.ComponentModel.DataAnnotations.Schema;

namespace JongSnamFootball.Entities.Models
{
    public class UserMemberModel
    {
        [Column("id_member")]
        public int Id { get; set; }

        [Column("email_member")]
        public string Email { get; set; }

        [Column("password_member")]
        public string Password { get; set; }

        [Column("firstname_member")]
        public string FirstName { get; set; }

        [Column("lastname_member")]
        public string LastName { get; set; }

        [Column("address_member")]
        public string Address { get; set; }

        [Column("telephone_member")]
        public string TelePhone { get; set; }

        [Column("picture_member")]
        public string Picture { get; set; }

        [Column("status_member")]
        public string Status { get; set; }
    }
}
