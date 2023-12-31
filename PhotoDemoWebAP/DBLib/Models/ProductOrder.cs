﻿namespace PhotoDemoWebAP.DBLib.Models
{
    public class ProductOrder
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string OrderId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public bool Cancelled { get; set; } = false;
    }
}
