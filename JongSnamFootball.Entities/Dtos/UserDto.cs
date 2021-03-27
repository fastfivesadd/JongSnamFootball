namespace JongSnamFootball.Entities.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactMobile { get; set; }
        public string Image { get; set; }
        public string UserType { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
