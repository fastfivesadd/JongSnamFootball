namespace JongSnamFootball.Entities.Models
{
    public class UserModel : BaseModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string ContactMobile { get; set; }

        public string ImageProfile { get; set; }

        public int UserTypeId { get; set; }
        public bool? IsLoggedIn { get; set; }
    }
}
