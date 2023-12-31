﻿using PhotoDemoWebAP.DBLib.Models;

namespace PhotoDemoWebAP.DBLib.Repositories.Interfaces
{
    public interface IGroupOrderRepository : IBaseRepository<GroupOrder>
    {
        void Update(GroupOrder groupOrder);
        void UpdateUserData(string groupOrderId, string name, string email);
    }
}
