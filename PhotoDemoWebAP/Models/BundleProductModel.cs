using PhotoDemoWebAP.DBLib.Models;

namespace PhotoDemoWebAP.Models
{
    public class BundleProductModel
    {
        public string BundleId { get; set; } = string.Empty;
        public string BundleTitle { get; set; } = string.Empty;
        public string BundleDescription { get; set; } = string.Empty;
        public Product[] ProductList { get; set; } = new Product[0];
    }
}
