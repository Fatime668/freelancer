using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Models
{
    public class AppUser:IdentityUser
    {
        [Required,StringLength(maximumLength:20)]
        public string Firstname { get; set; }
        [Required, StringLength(maximumLength: 20)]
        public string Lastname { get; set; }
    }
}
