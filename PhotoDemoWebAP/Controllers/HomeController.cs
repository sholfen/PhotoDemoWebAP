using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;
using PhotoDemoWebAP.AppServices;
using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.Models;
using PhotoDemoWebAP.Utilities;
using System.Diagnostics;

namespace PhotoDemoWebAP.Controllers
{
    public class HomeController : Controller
    {
        private readonly NLog.ILogger _logger;
        private IOrderAppService _orderAppService;

        public HomeController(IOrderAppService orderAppService)
        {
            _logger = LogManager.Setup().GetLogger("GroupBuyDemo");
            _orderAppService = orderAppService;
        }

        public IActionResult Index()
        {
            _logger.Info("Home: Test Info");
            return View();
        }

        public IActionResult Product()
        {
            var model = CacheManager.BundleProductModel;
            return View(model);
        }

        [HttpPost]
        public IActionResult PreOrder([FromForm]string[] productList) 
        {
            string name = Request.Form["Name"];
            string email = Request.Form["Email"];
            List<Product> products = new List<Product>();
            foreach (var productId in productList) 
            {
                products.Add(CacheManager.Products[productId]);
            }
            GroupOrderModel groupOrderModel = new GroupOrderModel
            {
                BundleId = CacheManager.BundleProductModel.BundleId,
                Cancelled = false,
                GroupOrderId = Guid.NewGuid().ToString(),
                ProductIdList = productList,
                TotalPrice = Tools.PriceCalculator(products),
                UserEmail = email,
                UserName = name,
            };
            _orderAppService.AddGroupOrder(groupOrderModel);
            return RedirectToAction("OrderList");
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            List<GroupOrderModel> orderList = _orderAppService.ListGroupOrder();
            return View(orderList);
        }

        [HttpGet]
        public IActionResult DeleteOrder(string GroupOrderId)
        {
            _orderAppService.CancelGroupOrder(GroupOrderId);
            return RedirectToAction("OrderList");
        }

        public IActionResult EditOrder(string GroupOrderId) 
        {
            var groupOrder = _orderAppService.GetGroupOrderModel(GroupOrderId);
            if (Request.Method == "POST")
            {
                string name = Request.Form["UserName"];
                string email = Request.Form["UserEmail"];
                _orderAppService.UpdateUserData(GroupOrderId, name, email);
                return RedirectToAction("OrderList");
            }
            return View(groupOrder);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}