using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Newsletter.Data
{
    public class UserData
    {
        public int id { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
    }
}