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
        public required byte[] PasswordHash {get;set;}
        public required byte[] PasswordSalt { get; set; }
    }
}