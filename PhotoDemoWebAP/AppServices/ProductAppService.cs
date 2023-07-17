using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;
using PhotoDemoWebAP.Models;

namespace PhotoDemoWebAP.AppServices
{
    public class ProductAppService : IProductAppService
    {
        private IProductRepository _productRepository;
        private IBundleProductRepository _bundleProductRepository;

        public ProductAppService(IProductRepository productRepository, IBundleProductRepository bundleProductRepository) 
        {
            _productRepository = productRepository;
            _bundleProductRepository = bundleProductRepository;
        }

        public BundleProductModel GetBundleProduct()
        {
            //return _productRepository.Query().FirstOrDefault();
            return null;
        }
    }
}
