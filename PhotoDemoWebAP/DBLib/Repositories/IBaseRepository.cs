﻿namespace PhotoDemoWebAP.DBLib.Repositories
{
    public interface IBaseRepository<T>
    {
        int Insert(T parameter);
        List<T> Query(string col = "*");
        List<T> QueryBy(Dictionary<string, object> parameters);
    }
}
