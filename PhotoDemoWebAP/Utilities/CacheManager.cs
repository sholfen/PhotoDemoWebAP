using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Implements;
using PhotoDemoWebAP.Models;
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

        public static void PullBundleProductModelInCache()
        {
            BundleProductRepository bundleProductRepository = new BundleProductRepository();
            var bundleProduct = bundleProductRepository.Query().FirstOrDefault();
            List<Product> products = new List<Product>();
            foreach (string productId in bundleProduct.ProductIdList.Split(','))
            {
                string newProductId = productId.Trim();
                products.Add(Products[newProductId]);
            }
            BundleProductModel = new BundleProductModel
            {
                BundleId = bundleProduct.BundleId,
                BundleDescription = bundleProduct.BundleDescription,
                BundleTitle = bundleProduct.BundleTitle,
                ProductList = products.ToArray()
            };
        }

        public static ConcurrentDictionary<string, Product> Products = new ConcurrentDictionary<string, Product>();
        public static BundleProductModel BundleProductModel;
    }
}
