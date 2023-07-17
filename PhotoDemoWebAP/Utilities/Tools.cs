using PhotoDemoWebAP.DBLib.Models;
using PhotoDemoWebAP.DBLib.Repositories.Implements;
using PhotoDemoWebAP.DBLib.Repositories.Interfaces;
using System.Collections.Concurrent;

namespace PhotoDemoWebAP.Utilities
{
    public static class Tools
    {
        static Tools()
        {

        }

        /// <summary>
        /// 算總價，可放折扣邏輯在裡面
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static int PriceCalculator(List<Product> products)
        {
            int totalPricee = 0;

            foreach (var product in products)
            {
                totalPricee += product.Price;
            }

            return totalPricee;
        }
    }
}
