using Freelancer.DAL;
using Freelancer.Extensions;
using Freelancer.Models;
using Freelancer.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Areas.FreelancerAdmin.Controllers
{
    [Area("FreelancerAdmin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PortfolioController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Portfolio> portfolios = await _context.Portfolios.ToListAsync();
            return View(portfolios);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            if (!ModelState.IsValid) return View();
            if (portfolio.Photo != null)
            {
                if (!portfolio.Photo.IsOkay(1))
                {
                    portfolio.Image = await portfolio.Photo.FileCreate(_env.WebRootPath, @"assets\image");
                    await _context.AddAsync(portfolio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please, choose image file under the 1 mb");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Please,choose file");
                return View();
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            Portfolio portfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.Id == id);
            if (portfolio == null) return NotFound();
            return View(portfolio);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Portfolio portfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.Id == id);
            if (portfolio == null) return NotFound();
            return View(portfolio);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id,Portfolio portfolio)
        {
            if (!ModelState.IsValid) return View();
            Portfolio existedPortfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.Id == id);
            if (portfolio.Photo != null)
            {
                if (!portfolio.Photo.IsOkay(1))
                {
                    string path = _env.WebRootPath + @"assets\image" + existedPortfolio.Image;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    existedPortfolio.Image = await portfolio.Photo.FileCreate(_env.WebRootPath, @"assets\image");
                }
                else
                {
                    ModelState.AddModelError("Photo", "Please,choose photo under the 1 mb");
                    return View();
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }
        public async Task<IActionResult> Delete(int id)
        {
            Portfolio portfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.Id == id);

            if (portfolio == null) return NotFound();
            return View(portfolio);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            Portfolio portfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.Id == id);
            if (portfolio == null) return NotFound();
           
             _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
