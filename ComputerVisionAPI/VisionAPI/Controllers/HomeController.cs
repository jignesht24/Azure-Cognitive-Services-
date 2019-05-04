using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VisionAPI.Models;
using VisionAPI.Services;

namespace VisionAPI.Controllers
{
    public class HomeController : Controller
    {
        readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            AnalyzeImageService obj = new AnalyzeImageService();
            var response = await obj.MakeRequest(_configuration["ImagePath"], _configuration["subscriptionKey"], _configuration["EndPoint"]);

            return View(response);
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
