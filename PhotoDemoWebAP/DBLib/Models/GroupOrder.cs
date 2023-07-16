namespace PhotoDemoWebAP.DBLib.Models
{
    public class GroupOrder
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string GroupOrderId { get; set; } = string.Empty;
        public string[] OrderIdList { get; set; } = new string[0];
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public int TotalPrice { get; set; }
        public bool Cancelled { get; set; } = false;
    }
}
