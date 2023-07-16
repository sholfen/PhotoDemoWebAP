using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;

namespace PhotoDemoWebAP.DBLib.Repositories.Implements
{
    public class BundleProductRepository: BaseRepository<BundleProduct>, IBundleProductRepository
    {
        public BundleProductRepository() : base(DBTools.ConnectionString)
        {

        }
    }
}
