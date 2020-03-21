using System;

namespace HqFilling.Model
{
    public class UserModel : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PresentAddress { get; set; }
        public string ParmanentAddress { get; set; }
        
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
        public string ErrorDescription { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }
        public string Country { get; set; } 
    }
}
