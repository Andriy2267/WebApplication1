﻿namespace Mango.Web.Utility
{
    public class SD
    {
        public static string CouponAPIBase { get; set; } = string.Empty;
        public enum ApiType
        {
            POST,
            GET,
            PUT,
            DELETE
        }
    }
}
