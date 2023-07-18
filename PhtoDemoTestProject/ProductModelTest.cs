using PhotoDemoWebAP.DBLib;
using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Implements;
using PhotoDemoWebAP.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhtoDemoTestProject
{
    public class ProductModelTest
    {
        private string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=demo;Integrated Security=false;Trusted_Connection=true;";
        private string teststr = string.Empty;
        private BundleProductRepository bundleProductRepository;
        private ProductRepository productRepository;

        public ProductModelTest() 
        {
            teststr = "Test1";
            DBTools.ConnectionString = ConnectionString;
            bundleProductRepository = new BundleProductRepository();
            productRepository = new ProductRepository();
        }

        [Fact]
        public void Test1()
        {
            DBTools.ConnectionString = ConnectionString;
            if (teststr == "Test1")
            {
                Assert.True(true); return;
            }
            Assert.False(true);
        }

        [Fact]
        public void AddProduct()
        {
            string guid = Guid.NewGuid().ToString();
            string desc = "test desc";
            Product product = new Product()
            {
                ProductId = guid,
                Description = desc,
                Name = "AddProduct",
                Price = 1
            };
            productRepository.Insert(product);
            Product data = productRepository.Query().FirstOrDefault();
            if (data == null)
            {
                Assert.True(false);
                return;
            }
            if (data.ProductId != guid)
            {
                Assert.True(false);
                return;
            }
            Assert.True(true);
        }

        [Fact]
        public void AddProductAndQueryByCondition()
        {
            string guid = Guid.NewGuid().ToString();
            string desc = "test desc";
            Product product = new Product()
            {
                ProductId = guid,
                Description = desc,
                Name = "AddProductAndQueryByCondition",
                Price = 1
            };
            productRepository.Insert(product);
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("ProductId", guid);
            Product data = productRepository.QueryBy(param).FirstOrDefault();
            if (data == null)
            {
                Assert.True(false);
                return;
            }
            if (data.ProductId != guid)
            {
                Assert.True(false);
                return;
            }
            Assert.True(true);
        }

        [Fact]
        public void AddTwoProduct()
        {
            string product1Guid = Guid.NewGuid().ToString();
            string product2Guid = Guid.NewGuid().ToString();
            string desc = "test desc";
            Product product1 = new Product
            {
                ProductId = product1Guid,
                Description = desc,
                Name = "AddTwoProduct",
                Price = 1
            };
            Product product2 = new Product
            {
                ProductId = product2Guid,
                Description = desc,
                Name = "AddTwoProduct",
                Price = 1
            };
            productRepository.Insert(product1); 
            productRepository.Insert(product2);
            var datas = productRepository.Query();
            if (datas != null && datas.Count == 0)
            {
                Assert.True(false);
                return;
            }
            bool flag = false;
            foreach (var data in datas)
            {
                if (data.ProductId == product1Guid || data.ProductId == product2Guid)
                {
                    flag = true;
                }
            }
            if(flag)
            {
                Assert.True(true);
                return;
            }
            Assert.True(false);
        }

        [Fact]
        public void AddBundleProductProduct()
        {
            string bundleGuid = Guid.NewGuid().ToString();
            string product1Guid= Guid.NewGuid().ToString();
            string product2Guid = Guid.NewGuid().ToString();
            string productIdList = $"{product1Guid},{product2Guid}";
            BundleProduct bundleProduct = new BundleProduct
            {
                BundleTitle = "AddBundleProductProduct",
                BundleId = bundleGuid,
                BundleDescription = "test bundle desc",
                ProductIdList = productIdList
            };
            bundleProductRepository.Insert(bundleProduct);
            BundleProduct data = bundleProductRepository.Query().FirstOrDefault();
            if (data == null)
            {
                Assert.True(false);
                return;
            }
            if (data.BundleId != bundleGuid)
            {
                Assert.True(false);
                return;
            }
            if (data.ProductIdList != productIdList)
            {
                Assert.True(false);
                return;
            }
            Assert.True(true);
        }

        [Fact]
        public void AddBundleProductAndQueryByCondition()
        {
            string bundleGuid = Guid.NewGuid().ToString();
            string product1Guid = Guid.NewGuid().ToString();
            string product2Guid = Guid.NewGuid().ToString();
            string productIdList = $"{product1Guid},{product2Guid}";
            BundleProduct bundleProduct = new BundleProduct
            {
                BundleTitle = "AddBundleProductAndQueryByCondition",
                BundleId = bundleGuid,
                BundleDescription = "test bundle desc",
                ProductIdList = productIdList
            };
            bundleProductRepository.Insert(bundleProduct);
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("BundleId", bundleGuid);
            BundleProduct data = bundleProductRepository.QueryBy(param).FirstOrDefault();
            if (data == null)
            {
                Assert.True(false);
                return;
            }
            if (data.BundleId != bundleGuid)
            {
                Assert.True(false);
                return;
            }
            if (data.ProductIdList != productIdList)
            {
                Assert.True(false);
                return;
            }
            Assert.True(true);
        }

        [Fact]
        public void AddTwoBundleProductProduct()
        {
            string bundleGuid1 = Guid.NewGuid().ToString();
            string bundleGuid2 = Guid.NewGuid().ToString();
            string product1Guid = Guid.NewGuid().ToString();
            string product2Guid = Guid.NewGuid().ToString();
            string productIdList = $"{product1Guid},{product2Guid}";
            string desc = "test bundle desc";
            BundleProduct bundleProduct1 = new BundleProduct
            {
                BundleTitle = "AddTwoBundleProductProduct",
                BundleId = bundleGuid1,
                BundleDescription = desc,
                ProductIdList = productIdList
            };
            BundleProduct bundleProduct2 = new BundleProduct
            {
                BundleTitle = "AddTwoBundleProductProduct",
                BundleId = bundleGuid2,
                BundleDescription = desc,
                ProductIdList = productIdList
            };
            bundleProductRepository.Insert(bundleProduct1);
            bundleProductRepository.Insert(bundleProduct2);
            var datas = bundleProductRepository.Query();
            if (datas != null && datas.Count == 0)
            {
                Assert.True(false);
                return;
            }
            bool flag = false;
            foreach (var data in datas)
            {
                if (data.BundleId == bundleGuid1 || data.BundleId == bundleGuid2)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                Assert.True(true);
                return;
            }
            Assert.True(false);
        }

        [Fact]
        public void CalTotalPrice()
        {
            int totalPrice = 6;
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Price = 1,
                },
                new Product
                {
                    Price = 2,
                },
                new Product 
                {
                    Price = 3,
                }
            };
            int actTotalPrice = Tools.PriceCalculator(products);
            Assert.True(actTotalPrice == totalPrice);
        }
    }
}
