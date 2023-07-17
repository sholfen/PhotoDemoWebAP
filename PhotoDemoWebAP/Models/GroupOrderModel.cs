namespace PhotoDemoWebAP.Models
{
    public class GroupOrderModel
    {
        public string GroupOrderId { get; set; } = string.Empty;
        public string BundleId { get; set; } = string.Empty;
        public string[] ProductIdList { get; set; } = new string[0];
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public int TotalPrice { get; set; }
        public bool Cancelled { get; set; } = false;
    }
}
