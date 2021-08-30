using System;

namespace FirstTest.Core.Account
{
    public class Address
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 國家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 縣市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        /// 鄉鎮
        /// </summary>
        public string Township { get; set; }
        /// <summary>
        /// 區
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 村里
        /// </summary>
        public string Village { get; set; }
        /// <summary>
        /// 鄰
        /// </summary>
        public string Neighborhood { get; set; }
        /// <summary>
        /// 大道（Blvd.）
        /// </summary>
        public string Boulevard { get; set; }
        /// <summary>
        /// 路（Rd.）
        /// </summary>
        public string Road { get; set; }
        /// <summary>
        /// 街（St.）
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// 段（sec.）
        /// </summary>
        public string Section { get; set; }
        /// <summary>
        /// 巷（Ln.）
        /// </summary>
        public string Lane { get; set; }
        /// <summary>
        /// 弄（Aly.）
        /// </summary>
        public string Alley { get; set; }
        /// <summary>
        /// 號（No.）
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 樓（F）
        /// </summary>
        public int Floor { get; set; }
        /// <summary>
        /// 間、之（Rm.）
        /// </summary>
        public int Room { get; set; }
    }
}