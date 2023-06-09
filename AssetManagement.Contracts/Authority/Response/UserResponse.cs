﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Contracts.Authority.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Location { get; set; }

        public bool IsLoginFirstTime { get; set; }

        public DateTime Dob { get; set; }

        public string Email { get; set; }
    }
}
