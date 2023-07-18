using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;

namespace PhotoDemoWebAP.DBLib.Repositories.Implements
{
    public class OrderRepository: BaseRepository<ProductOrder>, IOrderRepository
    {
        public OrderRepository() : base(DBTools.ConnectionString)
        {

        }
    }
}
