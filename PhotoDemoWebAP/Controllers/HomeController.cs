using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using PhotoDemoWebAP.Models;
using System.Diagnostics;

namespace PhotoDemoWebAP.Controllers
{
    public class HomeController : Controller
    {
        private readonly NLog.ILogger _logger;

        public HomeController()
        {
            _logger = LogManager.Setup().GetLogger("GroupBuyDemo");
        }

        public IActionResult Index()
        {
            _logger.Info("Home: Test Info");
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