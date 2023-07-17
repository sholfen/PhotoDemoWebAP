using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Implements;
using System.Collections.Concurrent;

namespace PhotoDemoWebAP.Utilities
{
    public static class CacheManager
    {
        static CacheManager()
        {
            //ProductRepository productRepository = new ProductRepository();
            //var products = productRepository.Query();
            //foreach (var product in products)
            //{
            //    Products.TryAdd(product.ProductId, product);
            //}
        }

        public static void PullProductDataInCache()
        {
            Products = new ConcurrentDictionary<string, Product>();
            ProductRepository productRepository = new ProductRepository();
            var products = productRepository.Query();
            foreach (var product in products)
            {
                Products.TryAdd(product.ProductId, product);
            }
        }

        public static ConcurrentDictionary<string, Product> Products = new ConcurrentDictionary<string, Product>();
    }
}
