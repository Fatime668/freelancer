using Freelancer.DAL;
using Freelancer.Models;
using Freelancer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts =await _context.Abouts.ToListAsync();
            Info info = await _context.Infos.FirstOrDefaultAsync();
            List<Portfolio> portfolios = await _context.Portfolios.ToListAsync();
            HomeVM homeVM = new HomeVM
            {
                Abouts = abouts,
                Info = info,
                Portfolios = portfolios
            };

            return View(homeVM);
        }
    }
}
