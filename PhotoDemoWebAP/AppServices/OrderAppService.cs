using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;
using PhotoDemoWebAP.Models;
using PhotoDemoWebAP.Utilities;

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

        public void AddGroupOrder(GroupOrderModel groupOrderModel)
        {
            List<Product> products = new List<Product>();
            foreach (string productId in groupOrderModel.ProductIdList)
            {
                string orderId = Guid.NewGuid().ToString();
                var product = CacheManager.Products[productId];
                products.Add(product);
                Order order = new Order
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
            groupOrder.OrderIdList = string.Join(',', groupOrderModel.ProductIdList);
            _groupOrderRepository.Insert(groupOrder);
        }

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
    }
}
