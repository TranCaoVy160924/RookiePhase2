using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Domain.Models
{
    public class User : IdentityUser
    {
        public DateTime JoinedDate { get; set; } = DateTime.Now;
        public AssetManagement.Domain.Enums.UserGender Gender { get; set; }

        public virtual List<Assignment> Assignments { get; set; }
    }
}
