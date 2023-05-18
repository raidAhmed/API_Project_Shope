using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
namespace Agricultural.Application.DTOs.User
{
    public class UserUpdateDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public byte UserType { get; set; }
        public byte State { get; set; }
        public bool Active { get; set; }
        public bool Status { get; set; }
    }
}