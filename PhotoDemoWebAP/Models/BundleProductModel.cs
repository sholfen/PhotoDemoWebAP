using PhotoDemoWebAP.DBLib.Models;
using System.ComponentModel;

namespace PhotoDemoWebAP.Models
{
    public class BundleProductModel
    {
        public string BundleId { get; set; } = string.Empty;
        [DisplayName("商品套組名稱")]
        public string BundleTitle { get; set; } = string.Empty;
        [DisplayName("商品說明")]
        public string BundleDescription { get; set; } = string.Empty;
        public Product[] ProductList { get; set; } = new Product[0];
    }
}
