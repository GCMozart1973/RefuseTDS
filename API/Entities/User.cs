using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class User
    {
        public long Id { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public int? RoleID { get; set; }
        public long? CompanyID { get; set; }
        public long? RegionID { get; set; }
        public long? LocationID { get; set; }        
        public required string? Phone { get; set; }
        public long? Status { get; set; }
        public Boolean? PasswordReset { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}