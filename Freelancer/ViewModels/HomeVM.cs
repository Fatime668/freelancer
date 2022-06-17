using Freelancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.ViewModels
{
    public class HomeVM
    {
        public Setting Setting { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<About> Abouts { get; set; }
        public Info Info { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
