using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.Models;

namespace PhotoDemoWebAP.AppServices
{
    public interface IOrderAppService
    {
        void AddGroupOrder(GroupOrderModel groupOrder);
        void CancelGroupOrder(string groupOrderId);
        void UpdateOrderOfGroupOrder(string groupOrderId, string[] orderIdList);
        List<GroupOrderModel> ListGroupOrder();
        GroupOrderModel GetGroupOrderModel(string groupOrderId);
        void UpdateUserData(string groupOrderId, string name, string email);
    }
}
