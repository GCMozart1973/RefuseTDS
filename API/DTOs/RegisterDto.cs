using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {

        public required string Username { get; set; }
        public required string Firstname { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        public int? RoleID { get; set; }
        public long? CompanyID { get; set; }
        public long? LocationID { get; set; }
        public long? RegionID { get; set; }
        public string? Phone { get; set; }
        public long? Status { get; set; }
        public Boolean? PasswordReset { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public required string Password { get; set; }
    }
}