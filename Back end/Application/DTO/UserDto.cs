﻿namespace ApplicationLayer.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public List<int> records { get; set; }
    }
}
