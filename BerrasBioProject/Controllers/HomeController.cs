using BerrasBioProject.Data;
using BerrasBioProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BerrasBioProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly BerrasBioProjectContext _context;

        public HomeController(BerrasBioProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var BerrasBioContext = _context.Movies;
            return View(await BerrasBioContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}