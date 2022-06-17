using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string HeaderLogo { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
