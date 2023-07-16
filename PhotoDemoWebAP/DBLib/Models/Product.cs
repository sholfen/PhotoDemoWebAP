namespace PhotoDemoWebAP.DBLib.Models
{
    public class Product
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string ProductId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
