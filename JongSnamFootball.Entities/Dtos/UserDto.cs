﻿namespace JongSnamFootball.Entities.Dtos
{
    public class UserDto
    {

        public UserDto()
        {
                
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string TelePhone { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
    }
}
