using PhotoDemoWebAP.DBLib.Models;
using System.ComponentModel;

namespace PhotoDemoWebAP.Models
{
    public class GroupOrderModel
    {
        public string GroupOrderId { get; set; } = string.Empty;
        public string BundleId { get; set; } = string.Empty;
        public string[] ProductIdList { get; set; } = new string[0];
        [DisplayName("姓名")]
        public string UserName { get; set; } = string.Empty;
        [DisplayName("電子郵件")]
        public string UserEmail { get; set; } = string.Empty;
        [DisplayName("總金額")]
        public int TotalPrice { get; set; }
        public bool Cancelled { get; set; } = false;
        [DisplayName("品項")]
        public string ProductNameList { get; set; } = string.Empty;
    }
}
