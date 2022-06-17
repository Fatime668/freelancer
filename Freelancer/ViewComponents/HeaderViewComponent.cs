using Freelancer.DAL;
using Freelancer.Models;
using Freelancer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync();
            List<SocialMedia> socialMedias = await _context.SocialMedias.ToListAsync();
            HomeVM homeVM = new HomeVM
            {
                Setting = setting,
                SocialMedias = socialMedias
            };

            return View(homeVM);
        }
    }
}
