using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;

namespace PhotoDemoWebAP.DBLib.Repositories.Implements
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(DBTools.ConnectionString)
        {

        }
    }
}
