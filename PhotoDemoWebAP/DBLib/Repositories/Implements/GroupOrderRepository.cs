using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;

namespace PhotoDemoWebAP.DBLib.Repositories.Implements
{
    public class GroupOrderRepository: BaseRepository<GroupOrder>, IGroupOrderRepository
    {
        public GroupOrderRepository() : base(DBTools.ConnectionString)
        {

        }
    }
}
