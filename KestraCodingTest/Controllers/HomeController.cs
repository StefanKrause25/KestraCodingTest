using KestraCodingTest.Data;
using KestraCodingTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KestraCodingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KestraCodingTestContext _context;
        public HomeController(ILogger<HomeController> logger, KestraCodingTestContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index(IEnumerable<KestraCodingTest.Models.PetFormModel> model)
        {
            
            
            return View(_context.PetFormModel.ToList());
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
