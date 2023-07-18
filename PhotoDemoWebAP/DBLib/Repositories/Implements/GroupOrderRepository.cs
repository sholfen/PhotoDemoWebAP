using Dapper;
using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;
using System.Reflection.Metadata;

namespace PhotoDemoWebAP.DBLib.Repositories.Implements
{
    public class GroupOrderRepository: BaseRepository<GroupOrder>, IGroupOrderRepository
    {
        public GroupOrderRepository() : base(DBTools.ConnectionString)
        {

        }

        public void Update(GroupOrder groupOrder)
        {
            string query =
                $"UPDATE GroupOrder SET OrderIdList= @OrderIdList, TotalPrice = @TotalPrice, Cancelled = @Cancelled WHERE GroupOrderId = @GroupOrderId;";
            _sqlConnection.Execute(query, 
                new { OrderIdList = groupOrder.OrderIdList, TotalPrice = groupOrder.TotalPrice, Cancelled = groupOrder.Cancelled, 
                    GroupOrderId = groupOrder.GroupOrderId });
        }

        public void UpdateUserData(string groupOrderId, string name, string email)
        {
            string query =
                $"UPDATE GroupOrder SET UserName = @UserName, UserEmail = @Email WHERE GroupOrderId = @GroupOrderId;";
            _sqlConnection.Execute(query,
                new
                {
                    UserName = name,
                    Email = email,
                    GroupOrderId = groupOrderId
                });
        }
    }
}
