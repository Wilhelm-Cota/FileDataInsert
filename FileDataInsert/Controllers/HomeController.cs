using FileDataInsert.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileDataInsert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if(file != null) {
                string folder = "Documents/";
                folder += Guid.NewGuid().ToString()+ file.FileName;

                //file.ImagineUrl = folder  ### to insert the url into the database
                string serverFolder = Path.Combine(_environment.WebRootPath,folder);

                file.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            return View();
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