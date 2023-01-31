﻿namespace HazarHospital.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string AdminCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
       
    }
}
