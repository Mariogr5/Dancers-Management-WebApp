﻿using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace ptt_api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string ContactEmail { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}