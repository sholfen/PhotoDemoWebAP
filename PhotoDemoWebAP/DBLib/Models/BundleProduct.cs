﻿namespace PhotoDemoWebAP.DBLib.Models
{
    public class BundleProduct
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string BundleId { get; set; } = string.Empty;
        public string BundleTitle { get; set; } = string.Empty;
        public string BundleDescription { get; set; } = string.Empty;
        public string ProductIdList { get; set; } = string.Empty;
    }
}
