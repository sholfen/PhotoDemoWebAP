using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;
using PhotoDemoWebAP.Models;
using PhotoDemoWebAP.Utilities;
using PhotoDemoWebAP.Utilities.AOP;

namespace PhotoDemoWebAP.AppServices
{
    public class OrderAppService : IOrderAppService
    {
        private IOrderRepository _orderRepository;
        private IGroupOrderRepository _groupOrderRepository;

        public OrderAppService(IOrderRepository orderRepository, IGroupOrderRepository groupOrderRepository)
        {
            _orderRepository = orderRepository;
            _groupOrderRepository = groupOrderRepository;
        }

        [ExceptionLogging]
        public void AddGroupOrder(GroupOrderModel groupOrderModel)
        {
            if (groupOrderModel.ProductIdList.Count() == 0)
            {
                return;
            }

            List<Product> products = new List<Product>();
            List<string> productOrderIdList = new List<string>();
            foreach (string productId in groupOrderModel.ProductIdList)
            {
                string orderId = Guid.NewGuid().ToString();
                var product = CacheManager.Products[productId];
                products.Add(product);
                productOrderIdList.Add(orderId);
                ProductOrder order = new ProductOrder
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Cancelled = false,
                };
                _orderRepository.Insert(order);
            }
            GroupOrder groupOrder = new GroupOrder();
            string groupOrderId = Guid.NewGuid().ToString();
            groupOrder.GroupOrderId = groupOrderId;
            groupOrder.BundleId = groupOrderModel.BundleId;
            groupOrder.UserName = groupOrderModel.UserName;
            groupOrder.UserEmail = groupOrderModel.UserEmail;
            int totalPrice = Tools.PriceCalculator(products);
            groupOrder.TotalPrice = totalPrice;
            groupOrder.OrderIdList = string.Join(',', productOrderIdList);
            _groupOrderRepository.Insert(groupOrder);
        }

        [ExceptionLogging]
        public List<GroupOrderModel> ListGroupOrder()
        {
            List<GroupOrderModel> groupOrderModels = new List<GroupOrderModel>();
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("Cancelled", 0);
            var groupOrders = _groupOrderRepository.QueryBy(param);
            foreach (var groupOrder in groupOrders)
            {
                List<Product> productList = new List<Product>();
                foreach (var orderId in groupOrder.OrderIdList.Split(','))
                {
                    string newOrderId = orderId.Trim();
                    param = new Dictionary<string, object>();
                    param["OrderId"] = newOrderId;
                    var productOrder = _orderRepository.QueryBy(param).FirstOrDefault();
                    productList.Add(CacheManager.Products[productOrder.ProductId]);
                }
                GroupOrderModel groupOrderModel = new GroupOrderModel
                {
                    BundleId = groupOrder.BundleId,
                    Cancelled = groupOrder.Cancelled,
                    GroupOrderId = groupOrder.GroupOrderId,
                    TotalPrice = groupOrder.TotalPrice,
                    UserEmail = groupOrder.UserEmail,
                    UserName = groupOrder.UserName,
                    ProductNameList = string.Join(',', productList.Select(p => p.Name).ToList()),
                };
                groupOrderModels.Add(groupOrderModel);
            }

            return groupOrderModels;
        }

        [ExceptionLogging]
        public GroupOrderModel GetGroupOrderModel(string groupOrderId)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("GroupOrderId", groupOrderId);
            GroupOrder groupOrder = _groupOrderRepository.QueryBy(param).FirstOrDefault();
            GroupOrderModel groupOrderModel = new GroupOrderModel
            {
                BundleId = groupOrder.BundleId,
                Cancelled = groupOrder.Cancelled,
                GroupOrderId = groupOrder.GroupOrderId,
                ProductIdList = new string[0],
                ProductNameList = string.Empty,
                TotalPrice = groupOrder.TotalPrice,
                UserEmail = groupOrder.UserEmail,
                UserName = groupOrder.UserName,
            };
            return groupOrderModel;
        }

        [ExceptionLogging]
        public void CancelGroupOrder(string groupOrderId)
        {
            Dictionary<string, object> whereParam = new Dictionary<string, object>();
            whereParam.Add(nameof(GroupOrder.GroupOrderId), groupOrderId);
            var groupOrder = _groupOrderRepository.QueryBy(whereParam).FirstOrDefault();
            if (groupOrder != null)
            {
                groupOrder.Cancelled = true;
                _groupOrderRepository.Update(groupOrder);
            }
        }

        [ExceptionLogging]
        public void UpdateOrderOfGroupOrder(string groupOrderId, string[] orderIdList)
        {
            Dictionary<string, object> whereParam = new Dictionary<string, object>();
            whereParam.Add(nameof(GroupOrder.GroupOrderId), groupOrderId);
            var groupOrder = _groupOrderRepository.QueryBy(whereParam).FirstOrDefault();
            if (groupOrder != null)
            {
                groupOrder.OrderIdList = string.Join(",", orderIdList);
                _groupOrderRepository.Update(groupOrder);
            }
        }

        [ExceptionLogging]
        public void UpdateUserData(string groupOrderId, string name, string email)
        {
            _groupOrderRepository.UpdateUserData(groupOrderId, name, email);
        }
    }
}
